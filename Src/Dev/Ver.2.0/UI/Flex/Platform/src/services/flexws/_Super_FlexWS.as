/**
 * This is a generated class and is not intended for modification.  To customize behavior
 * of this service wrapper you may modify the generated sub-class of this class - FlexWS.as.
 */
package services.flexws
{
import com.adobe.fiber.core.model_internal;
import com.adobe.fiber.services.wrapper.WebServiceWrapper;
import com.adobe.serializers.utility.TypeUtility;
import mx.rpc.AbstractOperation;
import mx.rpc.AsyncToken;
import mx.rpc.soap.mxml.Operation;
import mx.rpc.soap.mxml.WebService;
import valueObjects.ApplicationFillResult_type;
import valueObjects.PS;
import valueObjects.SessionFillCreditsBalanceResult_type;
import valueObjects.SessionFillCreditsResult_type;
import valueObjects.SessionFillInboxResult_type;
import valueObjects.SessionFillLocalMembersResult_type;
import valueObjects.SessionFillOnlineMembersResult_type;
import valueObjects.SessionFillResult_type;
import valueObjects.SessionInitResult_type;

[ExcludeClass]
internal class _Super_FlexWS extends com.adobe.fiber.services.wrapper.WebServiceWrapper
{
     
    // Constructor
    public function _Super_FlexWS()
    {
        // initialize service control
        _serviceControl = new mx.rpc.soap.mxml.WebService();
        var operations:Object = new Object();
        var operation:mx.rpc.soap.mxml.Operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "Ping");
         operation.resultType = String;
        operations["Ping"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetLocation");
         operation.resultType = String;
        operations["SetLocation"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskRemoveFromBlackList");
         operation.resultType = String;
        operations["DontAskRemoveFromBlackList"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskReportSent");
         operation.resultType = String;
        operations["DontAskReportSent"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskBlockMember");
         operation.resultType = String;
        operations["DontAskBlockMember"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DeletePhoto");
         operation.resultType = String;
        operations["DeletePhoto"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "AddMemberFromBlackList");
         operation.resultType = String;
        operations["AddMemberFromBlackList"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskRemoveFromMyPhotos");
         operation.resultType = String;
        operations["DontAskRemoveFromMyPhotos"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "AddMemberToFavorites");
         operation.resultType = String;
        operations["AddMemberToFavorites"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SendReport");
         operation.resultType = String;
        operations["SendReport"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskInvitationSend");
         operation.resultType = String;
        operations["DontAskInvitationSend"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetProfile");
         operation.resultType = String;
        operations["SetProfile"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetOnLine");
         operation.resultType = String;
        operations["SetOnLine"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "BuyUnlimitedChat");
         operation.resultType = String;
        operations["BuyUnlimitedChat"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFillInbox");
         operation.resultType = valueObjects.SessionFillInboxResult_type;
        operations["SessionFillInbox"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SendPresent");
         operation.resultType = String;
        operations["SendPresent"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskFeedbackSent");
         operation.resultType = String;
        operations["DontAskFeedbackSent"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "RemoveMemberFromFavorites");
         operation.resultType = String;
        operations["RemoveMemberFromFavorites"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetLocale");
         operation.resultType = String;
        operations["SetLocale"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "GetPS");
         operation.resultType = valueObjects.PS;
        operations["GetPS"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "ApplicationFill");
         operation.resultType = valueObjects.ApplicationFillResult_type;
        operations["ApplicationFill"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "ShareMemberWithAFriend");
         operation.resultType = String;
        operations["ShareMemberWithAFriend"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFillOnlineMembers");
         operation.resultType = valueObjects.SessionFillOnlineMembersResult_type;
        operations["SessionFillOnlineMembers"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionInit");
         operation.resultType = valueObjects.SessionInitResult_type;
        operations["SessionInit"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskTwinkSent");
         operation.resultType = String;
        operations["DontAskTwinkSent"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskProfileUpdated");
         operation.resultType = String;
        operations["DontAskProfileUpdated"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DeleteMemberInbox");
         operation.resultType = String;
        operations["DeleteMemberInbox"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFillCredits");
         operation.resultType = valueObjects.SessionFillCreditsResult_type;
        operations["SessionFillCredits"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFillCreditsBalance");
         operation.resultType = valueObjects.SessionFillCreditsBalanceResult_type;
        operations["SessionFillCreditsBalance"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SendFeedback");
         operation.resultType = String;
        operations["SendFeedback"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetOffLine");
         operation.resultType = String;
        operations["SetOffLine"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFill");
         operation.resultType = valueObjects.SessionFillResult_type;
        operations["SessionFill"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetMemberCommAsRead");
         operation.resultType = String;
        operations["SetMemberCommAsRead"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SessionFillLocalMembers");
         operation.resultType = valueObjects.SessionFillLocalMembersResult_type;
        operations["SessionFillLocalMembers"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "ShareWithAFriend");
         operation.resultType = String;
        operations["ShareWithAFriend"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "IsLinked");
         operation.resultType = Boolean;
        operations["IsLinked"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "BuyAPresent");
         operation.resultType = String;
        operations["BuyAPresent"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "GetLocation");
         operation.resultType = String;
        operations["GetLocation"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskRemoveFromFavorites");
         operation.resultType = String;
        operations["DontAskRemoveFromFavorites"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SetRadius");
         operation.resultType = String;
        operations["SetRadius"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SendText");
         operation.resultType = String;
        operations["SendText"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "SendTwink");
         operation.resultType = String;
        operations["SendTwink"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "DontAskAddToFavorites");
         operation.resultType = String;
        operations["DontAskAddToFavorites"] = operation;

        operation = new mx.rpc.soap.mxml.Operation(null, "RemoveMemberFromBlackList");
         operation.resultType = String;
        operations["RemoveMemberFromBlackList"] = operation;

        _serviceControl.operations = operations;
        try
        {
            _serviceControl.convertResultHandler = com.adobe.serializers.utility.TypeUtility.convertResultHandler;
        }
        catch (e: Error)
        { /* Flex 3.4 and eralier does not support the convertResultHandler functionality. */ }



        _serviceControl.service = "FlexWS";
        _serviceControl.port = "FlexWSSoap";
        wsdl = "http://www.datepercent.info/WS/FlexWS.asmx?WSDL";
        model_internal::loadWSDLIfNecessary();


        model_internal::initialize();
    }

    /**
      * This method is a generated wrapper used to call the 'Ping' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function Ping() : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("Ping");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send() ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetLocation' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetLocation(p_strSID:String, p_decLat:Number, p_decLng:Number) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetLocation");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_decLat,p_decLng) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskRemoveFromBlackList' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskRemoveFromBlackList(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskRemoveFromBlackList");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskReportSent' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskReportSent(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskReportSent");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskBlockMember' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskBlockMember(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskBlockMember");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DeletePhoto' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DeletePhoto(p_strSID:String, p_iPhotoID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DeletePhoto");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iPhotoID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'AddMemberFromBlackList' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function AddMemberFromBlackList(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("AddMemberFromBlackList");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskRemoveFromMyPhotos' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskRemoveFromMyPhotos(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskRemoveFromMyPhotos");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'AddMemberToFavorites' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function AddMemberToFavorites(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("AddMemberToFavorites");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SendReport' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SendReport(p_strSID:String, p_strName:String, p_strEMail:String, p_strBody:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SendReport");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strName,p_strEMail,p_strBody) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskInvitationSend' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskInvitationSend(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskInvitationSend");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetProfile' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetProfile(p_strSID:String, p_strNickName:String, p_iDistanceUnitsTypeCode:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetProfile");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strNickName,p_iDistanceUnitsTypeCode) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetOnLine' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetOnLine(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetOnLine");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'BuyUnlimitedChat' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function BuyUnlimitedChat(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("BuyUnlimitedChat");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFillInbox' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFillInbox(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFillInbox");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SendPresent' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SendPresent(p_strSID:String, p_iMemberID:int, p_iPresentTypeCode:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SendPresent");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID,p_iPresentTypeCode) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskFeedbackSent' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskFeedbackSent(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskFeedbackSent");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'RemoveMemberFromFavorites' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function RemoveMemberFromFavorites(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("RemoveMemberFromFavorites");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetLocale' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetLocale(p_strSID:String, p_iLocaleCode:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetLocale");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iLocaleCode) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'GetPS' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function GetPS(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("GetPS");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'ApplicationFill' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function ApplicationFill(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("ApplicationFill");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'ShareMemberWithAFriend' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function ShareMemberWithAFriend(p_strSID:String, p_strMemberUID:String, p_strEMail:String, p_strBody:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("ShareMemberWithAFriend");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strMemberUID,p_strEMail,p_strBody) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFillOnlineMembers' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFillOnlineMembers(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFillOnlineMembers");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionInit' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionInit(p_strSID:String, p_strToken:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionInit");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strToken) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskTwinkSent' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskTwinkSent(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskTwinkSent");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskProfileUpdated' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskProfileUpdated(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskProfileUpdated");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DeleteMemberInbox' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DeleteMemberInbox(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DeleteMemberInbox");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFillCredits' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFillCredits(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFillCredits");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFillCreditsBalance' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFillCreditsBalance(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFillCreditsBalance");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SendFeedback' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SendFeedback(p_strSID:String, p_strName:String, p_strEMail:String, p_strBody:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SendFeedback");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strName,p_strEMail,p_strBody) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetOffLine' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetOffLine(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetOffLine");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFill' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFill(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFill");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetMemberCommAsRead' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetMemberCommAsRead(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetMemberCommAsRead");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SessionFillLocalMembers' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SessionFillLocalMembers(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SessionFillLocalMembers");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'ShareWithAFriend' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function ShareWithAFriend(p_strSID:String, p_strEMail:String, p_strBody:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("ShareWithAFriend");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strEMail,p_strBody) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'IsLinked' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function IsLinked(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("IsLinked");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'BuyAPresent' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function BuyAPresent(p_strSID:String, p_iMemberID:int, p_iPresentCode:int, p_iPresentCost:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("BuyAPresent");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID,p_iPresentCode,p_iPresentCost) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'GetLocation' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function GetLocation(p_strSID:String, p_strAddress:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("GetLocation");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_strAddress) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskRemoveFromFavorites' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskRemoveFromFavorites(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskRemoveFromFavorites");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SetRadius' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SetRadius(p_strSID:String, p_iRadiusKm:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SetRadius");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iRadiusKm) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SendText' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SendText(p_strSID:String, p_iMemberID:int, p_strText:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SendText");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID,p_strText) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'SendTwink' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function SendTwink(p_strSID:String, p_iMemberID:int, p_iTwinkTypeCode:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("SendTwink");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID,p_iTwinkTypeCode) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'DontAskAddToFavorites' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function DontAskAddToFavorites(p_strSID:String) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("DontAskAddToFavorites");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID) ;

        return _internal_token;
    }
     
    /**
      * This method is a generated wrapper used to call the 'RemoveMemberFromBlackList' operation. It returns an mx.rpc.AsyncToken whose 
      * result property will be populated with the result of the operation when the server response is received. 
      * To use this result from MXML code, define a CallResponder component and assign its token property to this method's return value. 
      * You can then bind to CallResponder.lastResult or listen for the CallResponder.result or fault events.
      *
      * @see mx.rpc.AsyncToken
      * @see mx.rpc.CallResponder 
      *
      * @return an mx.rpc.AsyncToken whose result property will be populated with the result of the operation when the server response is received.
      */
    public function RemoveMemberFromBlackList(p_strSID:String, p_iMemberID:int) : mx.rpc.AsyncToken
    {
        model_internal::loadWSDLIfNecessary();
        var _internal_operation:mx.rpc.AbstractOperation = _serviceControl.getOperation("RemoveMemberFromBlackList");
        var _internal_token:mx.rpc.AsyncToken = _internal_operation.send(p_strSID,p_iMemberID) ;

        return _internal_token;
    }
     
}

}
