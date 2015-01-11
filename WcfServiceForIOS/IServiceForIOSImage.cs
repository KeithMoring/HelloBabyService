using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.IO;
using WcfServiceForIOS.Model;

namespace WcfServiceForIOS
{
    [ServiceContract]
   public interface IServiceForIOSImage
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UploadFile",BodyStyle=WebMessageBodyStyle.Wrapped,ResponseFormat=WebMessageFormat.Json
            )]
        string SaveImage(Stream request);

        
    }
    

}
