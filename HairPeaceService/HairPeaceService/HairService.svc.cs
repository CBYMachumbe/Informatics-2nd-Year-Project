using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace HairPeaceService
{

    public class HairService : IHairService
    {
        dbConnectionDataContext db = new dbConnectionDataContext();

        public int searchProd(string SerialNumber)
        {
            //Storing Product Into CVariable
            var ProdFound = (from p in db.Products
                                 //Checking If Parameter ID matches the ID in the Database
                             where p.Serial_Number.Equals(SerialNumber)
                             select p).FirstOrDefault();

            //Checking If The PorductID is In The DataBase 
            if (ProdFound != null)
            {
                return ProdFound.ID;
            }
            else
            {
                return 0;
            }
        }

        //Getting all products from database
        public List<Prod> prodList()
        {
            List<Prod> pr = new List<Prod>();

            dynamic products = (from s in db.Products
                                select s);


            foreach(Product f in products)
            {
                var r = new Prod
                {
                    ID = f.ID,
                    sNumber = f.Serial_Number,
                    prodType = f.ProdType,
                    prodName = f.ProdName,
                    special = Convert.ToInt32(f.Special),
                    Price = Convert.ToDouble(f.Price),
                    brand = f.Brand,
                    description = f.Description,
                    Qty = Convert.ToInt32(f.Quantity),
                    Image = f.Image,
                    inStock = Convert.ToInt32(f.inStock)
               
                };

                pr.Add(r);
            }

            return pr;
        }

        //method used to find the product using an id in the database
        public int searchProdID(int ID)
        {
            //Storing Product Into CVariable
            var ProdFound = (from p in db.Products
                             //Checking If Parameter ID matches the ID in the Database
                             where p.ID.Equals(ID)
                             select p).FirstOrDefault();
            
            //Checking If The PorductID is In The DataBase 
            if (ProdFound != null)
            { 
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //allowing an already registered to gain access to the website
        public bool Login(string Email, string Password)
        {
            //checking whether password entered by user matches exsting one in the database
            var user = (from u in db.UserTables
                        where u.User_Email.Equals(Email) &&
                        
                        u.Password.Equals(Secrecy.HashPassword(Password)
                       )
                        select u).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            else
            {
               
                return false;
            }
        }

        //method to check if product thats being searched for 
        //exists in the database
        public bool Prod(string ID, string Name)
        {
            dynamic FoundProd = (from p in db.Products
                                 where p.ID.Equals(ID) && p.ProdName == Name
                                 select p).FirstOrDefault();

            if (FoundProd != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //adding a new user to the database
        public int Register(User details)
        {
            var NewUser = new UserTable
            {
                User_Name = details.Name,
                User_Surname = details.surname,
                User_Email = details.email,
                Password = Secrecy.HashPassword(details.pass),
                Active = details.active,
                UserType = details.type
            };
            db.UserTables.InsertOnSubmit(NewUser);
            try
            {
                db.SubmitChanges();
                return 1;
            }
            //Error Handling
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -1;
            }
        }

        //checking if user is registered before loging in
        public bool Registered(string Email, string Password)
        {
            dynamic UserReg = (from Reg in db.UserTables
                               where Reg.User_Email.Equals(Email) &&
                                     Reg.Password.Equals(Secrecy.HashPassword(Password))
                               select Reg).FirstOrDefault();

            if (UserReg == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Getting product from table
        public Prod GetProd(int ID)
        {
            var FoundProduct = (from p in db.Products
                             where p.ID.Equals(ID)
                             select p).FirstOrDefault();

            Prod pr = new Prod
            {
                ID = FoundProduct.ID,
                sNumber = FoundProduct.Serial_Number,
                prodType = FoundProduct.ProdType,
                prodName = FoundProduct.ProdName,
                special = Convert.ToInt32(FoundProduct.Special),
                Qty = Convert.ToInt32(FoundProduct.Quantity),
                Price = Convert.ToDouble(FoundProduct.Price),
                brand = FoundProduct.Brand,
                Image = FoundProduct.Image,
                inStock = Convert.ToInt32(FoundProduct.inStock),
                description = FoundProduct.Description
            };

            return pr;
        }

        //Edit Exsiting Product
        public bool modifyProd(Prod product, int ID)
        {
            var item = (from i in db.Products
                        where i.ID.Equals(ID)
                        select i).FirstOrDefault();

            item.Serial_Number = product.sNumber;
            item.ProdType = product.prodType;
            item.ProdName = product.prodName;
            item.Price = Convert.ToDouble(product.Price);
            item.Special = Convert.ToInt32(product.special);
            item.Quantity = Convert.ToInt32( product.Qty);
            item.Brand = product.brand;
            item.Image = product.Image;
            
            try
            {
                db.SubmitChanges();
                return true;
            }
            //Error Handling 
            catch (IndexOutOfRangeException ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Adding a new user
        public bool newProd(string ID)
        {
            dynamic part = (from p in db.Products
                            where p.ID.Equals(ID)
                            select p).FirstOrDefault();

            if (part == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Method for Add new Product To DataBase
        public bool appendNewProduct(Prod p)
        {
            var newProduct = new Product
            {
                Serial_Number = p.sNumber,
                ProdType = p.prodType,
                ProdName = p.prodName,
                Price = Convert.ToDouble(p.Price),
                Special = p.special,
                Description = p.description,
                Quantity = p.Qty,
                Brand = p.brand,
                Image = p.Image,
                inStock = 1
            };

            db.Products.InsertOnSubmit(newProduct);

            try
            {
                db.SubmitChanges();
                pStakerSetup(newProduct.ID,newProduct.Quantity);
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        //Getting cart items
        public List<userCart> GetCarts(int userId)
        {
            List<userCart> cart = new List<userCart>();

            dynamic entries = (from c in db.Carts
                               where c.User_ID.Equals(userId)
                               select c);

            foreach(Cart ct in entries)
            {
                userCart e = new userCart
                {
                    User_ID = ct.User_ID,
                    Prod_ID = ct.Prod_ID,
                    Quantity = Convert.ToInt32(ct.Quantity)
                };

                cart.Add(e);
            }

            return cart;
        }

        //Adding to cart
        public bool addToCart(int userID, int ProdID)
        {
            var exists = (from c in db.Carts
                           where c.User_ID.Equals(userID) && c.Prod_ID.Equals(ProdID)
                           select c).FirstOrDefault();

            if (exists != null) {
                exists.Quantity += 1;


                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    return false;
                }
            }
            Cart cc = new Cart()
            {
                User_ID = userID,
                Prod_ID=ProdID,
                Quantity=1,
            };
            db.Carts.InsertOnSubmit(cc);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }


        }

        //Removing from cart table
        public bool removeItem(int userID, int ProdID)
        {
            Cart entrie = (from c in db.Carts
                          where (c.User_ID.Equals(userID) && c.Prod_ID.Equals(ProdID))
                          select c).FirstOrDefault();

            db.Carts.DeleteOnSubmit(entrie);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        //Getting existing user from table
        public User GetUser(string Email, string Password)
        {
            var Ruser = (from u in db.UserTables
                        where u.User_Email.Equals(Email) &&
                        u.Password.Equals(Secrecy.HashPassword(Password))
                        select u).FirstOrDefault();

            User user = new User
            {
                ID = Ruser.ID,
                Name = Ruser.User_Name,
                surname = Ruser.User_Surname,
                email = Ruser.User_Email,
                pass = Ruser.Password,
                active = Convert.ToInt32(Ruser.Active),
                type = Ruser.UserType
            };

            return user;
        }

        //Filtering By Name
        public List<Prod> fillBySpecial()
        {
            List<Prod> list = new List<Prod>();

            dynamic prod = (from u in db.Products
                        where u.inStock.Equals(1) && u.Special.Equals(1)
                        select u);

            foreach (var f in prod)
            {
                var r = new Prod
                {
                    ID = f.ID,
                    sNumber = f.Serial_Number,
                    prodType = f.ProdType,
                    prodName = f.ProdName,
                    special = Convert.ToInt16(f.Special),
                    Price = Convert.ToDouble(f.Price),
                    brand = f.Brand,
                    description = f.Description,
                    Qty = Convert.ToInt16(f.Quantity),
                    Image = f.Image

                };

                list.Add(r);
            }
            return list;
        }
        
        //Filtering by product type
        public List<Prod> fillByProdType(string type)
        {
            List<Prod> list = new List<Prod>();

            var prod = (from u in db.Products
                        where u.ProdName.Equals(type) && u.inStock.Equals(1)
                        orderby u.Price ascending
                        select u);

            foreach (var f in prod)
            {
                var r = new Prod
                {
                    ID = f.ID,
                    sNumber = f.Serial_Number,
                    prodType = f.ProdType,
                    prodName = f.ProdName,
                    special = Convert.ToInt16(f.Special),
                    Price = Convert.ToDouble(f.Price),
                    brand = f.Brand,
                    description = f.Description,
                    Qty = Convert.ToInt16(f.Quantity),
                    Image = f.Image

                };

                list.Add(r);
            }
            return list;
        }

        public bool itemExists(int userID, int ProdID)
        {
            var exists = (from c in db.Carts
                          where c.User_ID.Equals(userID) && c.Prod_ID.Equals(ProdID)
                          select c).FirstOrDefault();

            if(exists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       

        public bool SearchUser(string Email)
        {
            UserTable UserReg = (from Reg in db.UserTables
                               where Reg.User_Email.Equals(Email)
                               select Reg).FirstOrDefault();

            if (UserReg == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public User GetAnonUser(string Email)
        {
            var Ruser = (from u in db.UserTables
                         where u.User_Email.Equals(Email) 
                         select u).FirstOrDefault();

            User user = new User
            {
                ID = Ruser.ID,
                Name = Ruser.User_Name,
                surname = Ruser.User_Surname,
                email = Ruser.User_Email,
                pass = Ruser.Password,
                active = Convert.ToInt32(Ruser.Active),
                type = Ruser.UserType
            };

            return user;
        }

        public int editUser(User details,string email)
        {

            UserTable NewUser = (from u in db.UserTables
                           where u.User_Email.Equals(email)
                           select u).FirstOrDefault();

            NewUser.User_Name = details.Name;
            NewUser.User_Surname = details.surname;
            NewUser.User_Email = details.email;
            NewUser.Active = details.active;
            NewUser.UserType = details.type;
            
            try
            {
                db.SubmitChanges();
                return 1;
            }
            //Error Handling
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -1;
            }
        }

        public int getTotalItems(int userId)
        {
            int total = 0;
            dynamic entries = (from c in db.Carts
                               where c.User_ID.Equals(userId)
                               select c);

            foreach(Cart i in entries)
            {
                total += Convert.ToInt32(i.Quantity);

            }

            return total;
        }

     

       


        public int addDetails(bDetails details)
        {
            var   newDetails= new billingDetail
            {
                OrderID = details.Order_ID,
                User_ID = details.User_ID,
                Name = details.Name,
                Surname = details.Surname,
                Email = details.Email,
                Province = details.Province,
                House_Adress = details.House_Adress,
                Street_Adress = details.Street_Adress,
                City = details.City,
                ZIP = details.ZIP,
                Phone = details.Phone
            };

            db.billingDetails.InsertOnSubmit(newDetails);

            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return 0;
            }
        }

        public bool AddTransaction(tHistory transaction)
        {
            TransactionHistory entry = new TransactionHistory
            {
                Prod_ID = transaction.Prod_ID,
                Order_ID = transaction.Order_ID,
                Date = transaction.Date,
                Quantity = transaction.Quantity
            };

            db.TransactionHistories.InsertOnSubmit(entry);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public bool ClearCart(int UserID)
        {
            dynamic entries = (from c in db.Carts
                               where c.User_ID.Equals(UserID)
                               select c);

            db.Carts.DeleteAllOnSubmit(entries);
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public List<tHistory> getInvoice(int order)
        {
            List<tHistory> transactionHistories = new List<tHistory>();

            dynamic tings = (from th in db.TransactionHistories
                             where th.Order_ID.Equals(order)
                             select th);

            foreach(TransactionHistory t in tings)
            {
                tHistory thi = new tHistory
                {
                    Order_ID = t.Order_ID,
                    Prod_ID = t.Prod_ID,
                    purchase_ID = t.Purchase_ID,
                    Quantity = Convert.ToInt32(t.Quantity),
                    Date = Convert.ToDateTime(t.Date)
                    
                };

                transactionHistories.Add(thi);
            }

            return transactionHistories;
        }

        public bDetails getBillDetail(int order)
        {
            billingDetail detail = (from det in db.billingDetails
                                    where det.OrderID.Equals(order)
                                    select det).FirstOrDefault();

            bDetails details = new bDetails
            {
                User_ID = detail.User_ID,
                Order_ID = detail.OrderID,
                City = detail.City,
                Email = detail.Email,
                House_Adress = detail.House_Adress,
                Name = detail.Name,
                Phone = detail.Phone,
                Province = detail.Province,
                Street_Adress = detail.Street_Adress,
                Surname = detail.Surname,
                ZIP = detail.ZIP
            };

            return details;

        }

        public bool OrderExists(int order)
        {
            dynamic tings = (from t in db.billingDetails
                             where t.OrderID.Equals(order)
                             select t);

            if(tings != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<tHistory> getInvoices(int UserID)
        {
            List<tHistory> transactionHistories = new List<tHistory>();

            dynamic tings = (from th in db.TransactionHistories
                             select th);

            foreach (TransactionHistory t in tings)
            {
                bDetails details = getBillDetail(t.Order_ID);

                if(details.User_ID.Equals(UserID))
                {
                    tHistory thi = new tHistory
                    {
                        Order_ID = t.Order_ID,
                        Prod_ID = t.Prod_ID,
                        purchase_ID = t.Purchase_ID,
                        Quantity = Convert.ToInt32(t.Quantity),
                        Date = Convert.ToDateTime(t.Date)

                    };

                    transactionHistories.Add(thi);
                }
            }

            return transactionHistories;
        }

        public List<Prod> fillByBrand(String bName)
        {
            List<Prod> list = new List<Prod>();

            var prod = (from u in db.Products
                        where u.inStock.Equals(1) && u.Brand.Equals(bName)
                        select u);
            foreach (var f in prod)
            {
                var r = new Prod
                {
                    ID = f.ID,
                    sNumber = f.Serial_Number,
                    prodType = f.ProdType,
                    prodName = f.ProdName,
                    special = Convert.ToInt32(f.Special),
                    Price = Convert.ToDouble(f.Price),
                    brand = f.Brand,
                    description = f.Description,
                    Qty = Convert.ToInt32(f.Quantity),
                    Image = f.Image

                };

                list.Add(r);
            }
            return list;
        }

        public List<string> htmlBrandFilter()
        {
            List<string> b = new List<string>();
            List<string> Brands = new List<string>();

            dynamic p = (from s in db.Products
                         select s);

            foreach (Product f in p)
            {
                string br = f.Brand;
                b.Add(br);
            }

            foreach (string brand in b.Distinct())
            {
                Brands.Add(brand);
            }
            return Brands;
        }

        public List<Prod> fillByPrice(int n)
        {
            List<Prod> p = new List<Prod>();
            if (n == 1)
            {
                var prod = (from u in db.Products
                            where u.inStock.Equals(1) && (u.Price > 0 && u.Price <= 50)
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }

            }
            else if (n == 2)
            {
                var prod = (from u in db.Products
                            where u.inStock.Equals(1) && (u.Price >= 50 && u.Price <= 100)
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }
            }
            else if (n == 3)
            {
                var prod = (from u in db.Products
                            where u.inStock.Equals(1) && (u.Price >= 100 && u.Price <= 200)
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }
            }

            return p;
        }

        public void UserLoggings(int UserID)
        {
            String sDate = DateTime.Now.ToString();
            DateTime dValue = (Convert.ToDateTime(sDate.ToString()));
            String strDay = dValue.Day.ToString();
            String strMonth = dValue.Month.ToString();
            String strYear = dValue.Year.ToString();
            String strDayID = strDay + "-" + strMonth + "-" + strYear;
            dynamic UL = (from u in db.UserLogins where u.UserIDs.Equals(UserID)&& u.Date.Equals(strDayID) select u).FirstOrDefault();//Checking if the User has lo
            if (UL!=null) {//If user already exist increase the number of times he has logged in today.
                /** 
                 *This is to check if there is a new user loggining in. If The user is not new it will just increment the number of 
                 * times the user has logged in.
                 * This code is meant excute if it already exists in the database
                 */
                 
                UL.NumberOfLogins++;
                try
                {
                    db.SubmitChanges();
                    
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    
                }
            }
            else
            {
                UserLogin U = new UserLogin()
                {
                    Date = strDayID,
                    UserIDs = UserID,
                    NumberOfLogins=1,
                
               
             
                
                };
                db.UserLogins.InsertOnSubmit(U);
                try
                {
                    db.SubmitChanges();

                }
                catch (Exception e)
                {
                    e.GetBaseException();

                }
                //The abouve code keeps tracks of how many times a specific user logins

                /**
                 * Now we going to use the dateId to check if an instance of the date already exists. If it does exist than 
                 * We will make the number of log ins equal to 1. We will just increment it.
                 */
                dynamic Day = (from d in db.LogIns where d.Date.Equals(strDayID) select d).FirstOrDefault();
                if (Day != null)
                {
                    Day.NumberOfLogins++;
                    try
                    {
                        db.SubmitChanges();

                    }
                    catch (Exception e)
                    {
                        e.GetBaseException();

                    }
                }
                else {
                    LogIn LG = new LogIn() {
                        Date = strDayID,
                        NumberOfLogins = 1,

                    };
                    db.LogIns.InsertOnSubmit(LG);
                    try
                    {
                        db.SubmitChanges();

                    }
                    catch (Exception e)
                    {
                        e.GetBaseException();

                    }

                }


            }
            
        }

        public void pStakerSetup(int productID, int productQuantity)
        {


            ProductStalker PS = new ProductStalker()
            {
                PS_ID = productID,
                P_SDate = DateTime.Now.ToString(),
                P_SQuantity=productQuantity,
            };
            db.ProductStalkers.InsertOnSubmit(PS);
            try
            {
                db.SubmitChanges();

            }
            catch (Exception e)
            {
                e.GetBaseException();

            }


        }

        public int increasingQ(int P_ID, int U_ID)
        {
            var exists = (from c in db.Carts
                          where c.User_ID.Equals(U_ID) && c.Prod_ID.Equals(P_ID)
                          select c).FirstOrDefault();

            if (exists.Quantity > 0)
            {
                ++exists.Quantity;
                try
                {
                    db.SubmitChanges();
                    
                    return exists.Quantity;

                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    --exists.Quantity;
                    return exists.Quantity;
                }
            }
            else
                return exists.Quantity;
        }

        //Reading from the database
        public int decreasingQ(int P_ID, int U_ID)
        {
            var exists = (from c in db.Carts
                          where c.User_ID.Equals(U_ID) && c.Prod_ID.Equals(P_ID)
                          select c).FirstOrDefault();

            if (exists.Quantity > 0)
            {
                --exists.Quantity;

                try
                {
                    db.SubmitChanges();
                    return exists.Quantity;
                }
                catch (Exception e)
                {
                    e.GetBaseException();
                    ++exists.Quantity;
                    return exists.Quantity;
                }
            }
            else if (exists.Quantity == 0 || exists.Quantity < 0)
            {
                db.Carts.DeleteOnSubmit(exists);
                return 0;
            }
            return exists.Quantity;

        }

        public int ActiveUsers()
        {
            dynamic users = (from u in db.UserTables
                             where u.Active.Equals(1)
                             select u);

            int counter = 0;
            foreach( UserTable i in users)
            {
                counter++;
            }

            return counter;
        }

        public int InactiveUsers()
        {
            dynamic users = (from u in db.UserTables
                             where u.Active.Equals(0)
                             select u);

            int counter = 0;
            foreach (UserTable i in users)
            {
                counter++;
            }

            return counter;
        }

        public List<Prod> fillByDescOrder(int A)
        {
            List<Prod> p = new List<Prod>();

            if (A == 1)
            {
                var prod = (from u in db.Products
                            orderby u.ProdName ascending
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }

            }
            else if (A == 2)
            {
                var prod = (from u in db.Products
                            orderby u.ProdName descending
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }

            }
            else if (A == 20)
            {
                var prod = (from u in db.Products
                            where u.Special.Equals(1)
                            select u);

                foreach (var f in prod)
                {
                    var r = new Prod
                    {
                        ID = f.ID,
                        sNumber = f.Serial_Number,
                        prodType = f.ProdType,
                        prodName = f.ProdName,
                        special = Convert.ToInt16(f.Special),
                        Price = Convert.ToDouble(f.Price),
                        brand = f.Brand,
                        description = f.Description,
                        Qty = Convert.ToInt16(f.Quantity),
                        Image = f.Image

                    };

                    p.Add(r);
                }
            }

            return p;
        }

        public List<PTracking> getTracking()
        {
            List<PTracking> trackings = new List<PTracking>();

            dynamic tracks = (from p in db.PageTrackings
                              select p);

            foreach(PageTracking t in tracks)
            {
                PTracking pt = new PTracking
                {
                    nVisists = t.nVisits,
                    pageName = t.Page_Name
                };

                trackings.Add(pt);
            }

            return trackings;
        }

        public void IncrementTracking(string pageName)
        {
            var page = (from p in db.PageTrackings
                        where p.Page_Name.Equals(pageName)
                        select p).FirstOrDefault();

            if(page != null)
            {
                page.nVisits++;
            }
            

            try
            {
                db.SubmitChanges();
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }

        public List<cLogInDays> Days()
        {
            var days = (from d in db.LogIns select d);
            List<cLogInDays> manyDays = new List<cLogInDays>();
            foreach(LogIn p in days) {
                cLogInDays c = new cLogInDays
                {
                    strDate=p.Date,
                    intNumberOfLogins=p.NumberOfLogins
                }
                ;

                manyDays.Add(c);
            }
            return manyDays;
        }

        public void TransactionTings(int pID, int Qty)
        {
            Product prod = (from p in db.Products
                            where p.ID.Equals(pID)
                            select p).FirstOrDefault();

            if(prod != null)
            {
                prod.Quantity = prod.Quantity - Qty;
            }

            try
            {
                db.SubmitChanges();
            }
            catch(Exception e)
            {
                e.GetBaseException();
            }
        }
    }
}
