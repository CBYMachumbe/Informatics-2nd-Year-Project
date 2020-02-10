using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HairPeaceService
{
  
    [ServiceContract]
    public interface IHairService
    {
        [OperationContract]
        Boolean Prod(String ID, String Name);

        [OperationContract]
        int searchProdID(int ID);
        [OperationContract]
        int searchProd(String SerialNumber);


        [OperationContract]
        Prod GetProd(int ID);

        [OperationContract]
        bool modifyProd(Prod product, int ID);

        [OperationContract]
        bool newProd(String ID);
        [OperationContract]
        bool appendNewProduct(Prod p);

        [OperationContract]
        bool Login(String Email, String Password);
        [OperationContract]
        User GetUser(string Email, string Password);
        [OperationContract]
        bool SearchUser(string Email);
        [OperationContract]
        User GetAnonUser(string Email);
        [OperationContract]
        int editUser(User u,string email);


        [OperationContract]
        bool Registered(String Email, String Password);
        [OperationContract]
        int Register(User u);

        [OperationContract]
        List<Prod> prodList();

        [OperationContract]
        List<Prod> fillBySpecial();
        [OperationContract]
        List<Prod> fillByProdType(string type);
        [OperationContract]
        List<Prod> fillByPrice(int n);
        [OperationContract]
        List<Prod> fillByBrand(String bName);
        [OperationContract]
        List<string> htmlBrandFilter();

        [OperationContract]
        List<userCart> GetCarts(int userId);
        [OperationContract]
        bool addToCart(int userID, int ProdID);
        [OperationContract]
        bool removeItem(int userID, int ProdID);
        [OperationContract]
        bool itemExists(int userID, int ProdID);
       
        [OperationContract]
        int getTotalItems(int userId);
        [OperationContract]
        int increasingQ(int P_ID, int U_ID);
        [OperationContract]
        int decreasingQ(int P_ID, int U_ID);
        [OperationContract]
        List<Prod> fillByDescOrder(int A);

        [OperationContract]
        int addDetails(bDetails details);

        [OperationContract]
        bool AddTransaction(tHistory transaction);
        [OperationContract]
        bool ClearCart(int UserID);
        [OperationContract]
        List<tHistory> getInvoice(int order);
        [OperationContract]
        bool OrderExists(int order);
        [OperationContract]
        List<tHistory> getInvoices(int UserID);

        [OperationContract]
        bDetails getBillDetail(int order);
        [OperationContract]
        void UserLoggings(int UserID);
        [OperationContract]
        void pStakerSetup(int productID, int productQuantity);


        [OperationContract]
        int ActiveUsers();
        [OperationContract]
        int InactiveUsers();

        [OperationContract]
        List<PTracking> getTracking();
        [OperationContract]
        void IncrementTracking(string pageName);
        [OperationContract]
        List<cLogInDays> Days();

        [OperationContract]
        void TransactionTings(int pID,int Qty);
    }
}