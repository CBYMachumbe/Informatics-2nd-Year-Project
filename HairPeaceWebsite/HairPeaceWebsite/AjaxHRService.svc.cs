using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using HairPeaceWebsite.PeaceReference;

namespace HairPeaceWebsite
{

    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AjaxHRService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:

        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        HairServiceClient c = new HairServiceClient();
        [WebGet]
        [OperationContract]
        public int ajaxCartI(int pID, int uID)
        {
            int newQ = 0;
            newQ = c.increasingQ(pID, uID);
            return newQ;
        }
        [WebGet]
        [OperationContract]
        public int ajaxCartD(int pID, int uID)
        {

            return c.decreasingQ(pID, uID);

        }
        [WebGet]
        [OperationContract]
        public int ajaxCartT(int uID)
        {
            return c.getTotalItems(uID);
        }
        [WebGet]
        [OperationContract]
        public bool ajaxCartA(int pID, int uID) {
            return c.addToCart(uID, pID);
        }
        [WebGet]
        [OperationContract]
        public Prod[] ajaxFillType(String type) {

            return c.fillByProdType(type);
        }
        [WebGet]
        [OperationContract]
        public bool ajaxRemove(int pID, int uID) {
            
            return c.removeItem(uID, pID);

        }

        // Add more operations here and mark them with [OperationContract]
    }
}
