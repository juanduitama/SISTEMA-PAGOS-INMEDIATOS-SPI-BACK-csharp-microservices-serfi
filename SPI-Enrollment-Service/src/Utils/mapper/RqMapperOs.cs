using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using domain.models;
using domain.models.enrollment;
using domain.models.openSearchModel;
using domain.models.redeban.response;

namespace application.mapper
{
    /// <summary>
    /// Utilidad para manejar encabezados HTTP
    /// </summary>
    public class RqMapperOs
    {

        private static readonly Random random = new Random();

        public RqMapperOs()
        {
        }

        ////Cabeceras de OS a Redeban
        //public OSDefinitive mapOSDefinitiveFromRequest(EnrollmentRq enrollmentRq)
        //{
        //    OSDefinitive osIndexDefinitive = new OSDefinitive();

        //    osIndexDefinitive.rqUID = enrollmentRq.enrollmenAccountHeaders.uuId;

        //    AcctInfo acctInfo = new AcctInfo();

        //    acctInfo.acctType = enrollmentRq.reqBPostAccountRelationship.acctInfo.acctType;
        //    acctInfo.acctId = enrollmentRq.reqBPostAccountRelationship.acctInfo.acctId;

        //    osIndexDefinitive.acctInfo = acctInfo;

        //    CustInfo custInfo = new CustInfo();
        //    custInfo.firstName = enrollmentRq.reqBPostAccountRelationship.custInfo.firstName;
        //    custInfo.secondName = enrollmentRq.reqBPostAccountRelationship.custInfo.secondName;
        //    custInfo.lastName = enrollmentRq.reqBPostAccountRelationship.custInfo.lastName;
        //    custInfo.secondLastName = enrollmentRq.reqBPostAccountRelationship.custInfo.secondLastName;
        //    custInfo.custLegalName = enrollmentRq.reqBPostAccountRelationship.custInfo.custLegalName;
        //    custInfo.custType = enrollmentRq.reqBPostAccountRelationship.custInfo.custType;

        //    CustIdent custIdent = new CustIdent();
        //    custIdent.custIdentType = enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentType;
        //    custIdent.custIdentId = enrollmentRq.reqBPostAccountRelationship.custInfo.custIdent.custIdentId;

        //    custInfo.custIdent = custIdent;

        //    CustContact custContact = new CustContact();
        //    custContact.custMobileNumber = enrollmentRq.reqBPostAccountRelationship.custInfo.custContact.custMobileNumber;
        //    custContact.custEmail = enrollmentRq.reqBPostAccountRelationship.custInfo.custContact.custEmail;

        //    custInfo.custContact = custContact;

        //    osIndexDefinitive.custInfo = custInfo;      

        //    Key key = new Key();
        //    key.keyType = enrollmentRq.reqBPostAccountRelationship.key.keyType;
        //    key.keyId = enrollmentRq.reqBPostAccountRelationship.key.keyId;
        //    key.keyStatus = enrollmentRq.reqBPostAccountRelationship.key.keyStatus;
        //    osIndexDefinitive.key = key;

        //    VaultInsc vaultInsc = new VaultInsc();
        //    vaultInsc.vaultName = enrollmentRq.reqBPostAccountRelationship.vaultInsc.vaultName;
        //    vaultInsc.flowService = enrollmentRq.reqBPostAccountRelationship.vaultInsc.flowService;
        //    vaultInsc.vaultId = enrollmentRq.reqBPostAccountRelationship.vaultInsc.vaultId;
        //    osIndexDefinitive.vaultInsc = vaultInsc;

        //    osIndexDefinitive.effDtCreate = enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtCreate;
        //    osIndexDefinitive.effDtModify = enrollmentRq.reqBPostAccountRelationship.effDtKey.effDtModify;
        //    return osIndexDefinitive;
        //}

        //public MsgInformationResponseSerfi mapOSMessageResponse(EnrollmentRq enrollmentRq, MessageInformation messageInformation)
        //{
        //    MsgInformationResponseSerfi msgInformationResponseSerfi = new MsgInformationResponseSerfi();
        //    Meta meta = new Meta();
        //    meta.uuid = enrollmentRq.enrollmenAccountHeaders.uuId;
        //    meta.timeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //    meta.systemId = "";
        //    msgInformationResponseSerfi.meta = meta;

        //    msgInformationResponseSerfi.statusCodigo = messageInformation.msgCode;
        //    msgInformationResponseSerfi.statusDesc = messageInformation.msgDescription;

        //    AditionalInfo aditionalInfoItem = new AditionalInfo();
        //    aditionalInfoItem.codigo = "";
        //    aditionalInfoItem.detalle = "";


        //    List<AditionalInfo> aditionalInfoList = new List<AditionalInfo>();
        //    aditionalInfoList.Add(aditionalInfoItem);

        //    msgInformationResponseSerfi.aditionalInfo = aditionalInfoList;


        //    Data data = new Data();
        //    //No siempre se llena este merchantId
        //    data.merchantId = "";
        //    msgInformationResponseSerfi.data = data;


        //    return msgInformationResponseSerfi;
        //}

    }

}
