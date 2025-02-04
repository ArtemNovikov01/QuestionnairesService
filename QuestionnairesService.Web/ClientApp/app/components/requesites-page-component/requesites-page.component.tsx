
import { GetInfoByBin } from "@/app/shared/models/form-models/getInfoByBinModel";
import { useState } from "react";
import { RequesitesEvents } from "./requesites-page-events";
import "./requesites-page.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { useDispatch } from "react-redux";
import { CreateRequesitesBank } from "@/app/shared/models/form-models/createRequesitesBank";
import { addRequesitesInfo, setRequesitesInfo } from "@/app/shared/stores/buisnessman-store/buisnessman.slice";

const getDataEvent = new RequesitesEvents()
let eteration = 0; 
let requesites: CreateRequesitesBank;
export default function Requesites(props: { index: number }){
  
 const dispatch = useDispatch();
    const index = props.index;
    const [HintOne, GetHintOne] = useState<boolean>(false)
    const [HintTwo, GetHintTwo] = useState<boolean>(false)
    const [formValues, setFormValues] = useState<GetInfoByBin>({
        bin: '',
        nameBankBranch: '',
        correspondentAccount: '',
        errorMessage:''
      });
      
const [PaymentAccount, setPaymentAccount] = useState('');

 requesites = {
  bankCode: formValues.bin,
  branchOfficeName: formValues.nameBankBranch,
   correspondentAccount: formValues.correspondentAccount,
   paymentAccount: PaymentAccount
 };

const CreateRequesites = (requesites:CreateRequesitesBank) => {
  if(requesites.bankCode != '' && eteration === 0){
    dispatch(addRequesitesInfo(requesites));
  }
  else{
    dispatch(setRequesitesInfo({
      bin:requesites.bankCode,
      nameBankBranch: requesites.branchOfficeName,
      correspondentAccount: requesites.correspondentAccount,
      paymentAccount: requesites.paymentAccount,
      index: index
    }));
  }
}

  const [ErrorMessage, setErrorMessage] = useState('');
    return(
        <div className="container-fluid">
          <div className="row">
            <div className="col-4">
              <label className="form-text custom-label">БИК*</label>
              <input
                name="Bin"
                defaultValue={formValues.bin}
                onChange={async (e) =>{
                  const requesites = await getDataEvent.getData(index, e.target.value,PaymentAccount, setFormValues);
                  CreateRequesites(requesites);
                  eteration++;
                  }}
                className="form-control"
                placeholder="xxxxxxxxx"
              />
              
              <p className="custom-message-error">{formValues.errorMessage}</p>
            </div>
            <div className="col-8">
                <label className="form-text custom-label">Наименование филиала банка*</label>
                <div className="d-flex align-items-center flex-grow-1  input-with-button">
                  <input
                    name="NameBankBranch"
                    value={formValues.nameBankBranch}
                    onChange={(e) =>{
                      setFormValues({ ...formValues, nameBankBranch: e.target.value })
                      requesites.branchOfficeName = e.target.value
                      CreateRequesites(requesites);
                      console.log(requesites)
                      eteration++;
                    }}
                    className="form-control flex-grow-1"
                    placeholder="ООО &laquo;Московская промышленная компания&raquo;"
                  />
                  <p className="input-button">Заполнить</p>
                  <FontAwesomeIcon 
                    onMouseOver={(e) => getDataEvent.getHint(GetHintOne)} 
                    onMouseOut={(e) => getDataEvent.removeHint(GetHintOne)}
                    className="custom-picture-info ms-2" 
                    icon={faInfoCircle}/>
                  {HintOne && 
                        (<div className="popup-one">
                             <span className="popup-text-one">Автоматическое заполнение <br/>
                             названия филиала банка по БИК</span>
                         </div>)}
                </div>
            </div>
          </div>
          <div className="row">
            <div className="col-4">
              <label className="form-text custom-label">Рассчетный счёт*</label>
              <input
                value={PaymentAccount}
                name="PaymentAccount"
                onChange={(e) => {
                    getDataEvent.setPaymentAccount(e.target.value, setPaymentAccount,setErrorMessage);
                    requesites.paymentAccount = e.target.value
                      CreateRequesites(requesites);
                      console.log(requesites)
                      eteration++;}} 
                className="form-control"
                placeholder="xxxxxxxxxxxxxxxxxxxx"
              />
                <p className="custom-message-error">{ErrorMessage}</p>
            </div>
            <div className="col-7">
              <label className="form-text custom-label">Корреспондентский счёт*</label>
              <div className="d-flex align-items-center flex-grow-1 input-with-button">
                <input
                    value={formValues.correspondentAccount}
                    onChange={(e) =>{
                      setFormValues({ ...formValues, correspondentAccount: e.target.value });
                      requesites.correspondentAccount = e.target.value;
                      CreateRequesites(requesites);
                      console.log(requesites)
                      eteration++;
                    }}
                  name="CorrespondentAccount"
                  className="form-control flex-grow-1"
                  type="text"
                  placeholder="xxxxxxxxxxxxxxxxxxxx" />
                  <p className="input-button">Заполнить</p>
                    {HintTwo && 
                        (<div className="popup-two">
                             <span className="popup-text-two">Автоматическое заполнение <br/>
                               корреспондентского счета по БИК</span>
                         </div>)}
                <FontAwesomeIcon 
                    onMouseOver={(e) => getDataEvent.getHint(GetHintTwo)} 
                    onMouseOut={(e) => getDataEvent.removeHint(GetHintTwo)} 
                    className="custom-picture-info ms-2" 
                    icon={faInfoCircle}/>
              </div>
            </div>
          </div>
        </div>
    )
}

