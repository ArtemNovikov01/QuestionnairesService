import { useState } from "react";
import { LimitedLiabilityCompanyEvents } from "./limitedLiability-company-page-events"
import { GetInfoByInn } from "@/app/shared/models/form-models/getInfoByInnModel";
import "./limitedLiability-company-page.css"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';
import { CreateBuisnessman } from "@/app/shared/models/form-models/createBuisnessmanModel";

// Используйте компонент FontAwesomeIcon



const getDataEvent = new LimitedLiabilityCompanyEvents()

export default function LimitedLiabilityCompany(){
    const [Buisnessman, setBuisnessman] = useState<CreateBuisnessman>({
      inn: '',
      fullName: '',
      shortName: '',
      registrationNumber: '',
      registrationDate: new Date,
      SkanInn: undefined,
      SkanOgrnip: undefined,
      SkanResponseEgrip: undefined,
      SkanContractRent: undefined,
      AvailabilityContract: false,
      requesitesBanks:[] 
    });

    const [requesitesForm, setrequesitesForm] = useState<React.ReactNode[]>([]);
    const [formValues, setFormValues] = useState<GetInfoByInn>({
        inn: '',
        fullName: '',
        shortName: '',
        registrationNumber: '',
        registrationDate: undefined,
        errorMessage:''
      });
      
    const [SkanInn, setSkanInn] = useState<File | null>(null);
    const [SkanOgrnip, setSkanOgrnip] = useState<File | null>(null);
    const [SkanResponseEgrip, setSkanResponseEgrip] = useState<File | null>(null);
    const [SkanContractRent, setSkanContractRent] = useState<File | null>(null);
    const [AvailabilityContract, setAvailabilityContract] = useState<boolean>(false);

    const isValidForm = () => {
      const formValid = /^\d{10}$/.test(formValues.inn)
        && formValues.fullName 
        && formValues.shortName 
        && /^\d{13}$/.test(formValues.registrationNumber)
        && formValues.registrationDate
      return formValid
        && SkanInn 
        && SkanOgrnip 
        && SkanResponseEgrip 
        && (SkanContractRent || AvailabilityContract);
    };

    const isAvailabilityContract = () => {
        return !AvailabilityContract;
      };

    const isSkanContractRent = () => {
        return !SkanContractRent;
      };

    return(
        <div className="container-fluid">
            <p className="custom-paragraph">Общество с ограниченной ответственностью (ООО)</p>
            <form className="col-12">
              <div className="row">
                <div className="col-6">
                  <label className="form-text custom-label">Наименование полное*</label>
                  <input
                    name="fullName"
                    value={formValues.fullName}
                    onChange={(e) =>
                      setFormValues({ ...formValues, fullName: e.target.value })
                    }
                    className="form-control"
                    placeholder="ООО &laquo;Московская промышленная компания&raquo;"
                  />
                </div>
                <div className="col-4">
                  <label className="form-text custom-label">Наименование сокращенное*</label>
                  <input
                    name="shortName"
                    value={formValues.shortName}
                    onChange={(e) =>
                      setFormValues({ ...formValues, shortName: e.target.value })
                    }
                    className="form-control"
                    placeholder="ООО &laquo;МПК&raquo;"
                  />
                </div>
                <div className="col-2">
                  <label className="form-text custom-label">Дата регистрации*</label>
                  <input
                    name="dateRegistration"
                    value={
                      formValues.registrationDate
                        ? formValues.registrationDate.toISOString().slice(0, 10)
                        : 'xxxxxxxxxx'
                    }
                    onChange={(e) =>
                      setFormValues({
                        ...formValues,
                        registrationDate: new Date(e.target.value),
                      })
                    }
                    className="form-control"
                    type="date"
                  />
                </div>
              </div>
              <div className="row">
                <div className="col-2">
                  <label className="form-text custom-label">ИНН*</label>
                  <input
                    defaultValue={formValues.inn}
                    name="Inn"
                    onChange={(e) => {
                        getDataEvent.getData(e.target.value, setFormValues)
                        }} 
                    className="form-control"
                    placeholder="xxxxxxxxxx"
                  />
                  <p className="custom-message-error">{formValues.errorMessage}</p>
                </div>
                <div className="col-4">
                  <label className="form-text custom-label">Скан ИНН*</label>
                  <div className="input-group mb-3">
                    <input
                        onChange={(e) => {
                        if (e.target.files && e.target.files.length > 0) {
                            getDataEvent.setFile(e.target.files[0], setSkanInn);
                        }
                        else{
                            getDataEvent.setFile(null, setSkanInn);
                        }
                      }}
                      name="SkanInn"
                      className="form-control"
                      type="file"
                      placeholder="Выберите или перетащите файл"
                    />
                    <span className="input-group-text">
                      <i className="fas fa-upload"></i>
                    </span>
                  </div>
                </div>
                <div className="col-2">
                  <label className="form-text custom-label">ОГРН*</label>
                  <input
                    name="Ogrnip"
                    value={formValues.registrationNumber}
                    onChange={(e) =>
                      setFormValues({ ...formValues, registrationNumber: e.target.value })
                    }
                    className="form-control"
                    placeholder="xxxxxxxxxxxxxxx"
                  />
                </div>
                <div className="col-4">
                  <label className="form-text custom-label">Скан ОГРН*</label>
                  <div className="input-group mb-3">
                    <input
                        onChange={(e) => {
                        if (e.target.files && e.target.files.length > 0) {
                            getDataEvent.setFile(e.target.files[0], setSkanOgrnip);
                        }
                        else{
                            getDataEvent.setFile(null, setSkanOgrnip);
                        }
                      }}
                      name="SkanOgrnip"
                      className="form-control"
                      type="file"
                      placeholder="Выберите или перетащите файл"
                    />
                    <span className="input-group-text">
                      <i className="fas fa-upload"></i>
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-4">
                  <label className="form-text custom-label">
                    Скан выписки из ЕГРИП (не старше 3 месяцев)*
                  </label>
                  <div className="input-group mb-3">
                    <input
                        onChange={(e) => {
                        if (e.target.files && e.target.files.length > 0) {
                            getDataEvent.setFile(e.target.files[0], setSkanResponseEgrip);
                        }
                        else{
                            getDataEvent.setFile(null, setSkanResponseEgrip);
                        }
                      }}
                      name="SkanResponseEgrip"
                      className="form-control"
                      type="file"
                      placeholder="Выберите или перетащите файл"
                    />
                    <span className="input-group-text">
                      <i className="fas fa-upload"></i>
                    </span>
                  </div>
                </div>
                <div className="col-4">
                  <label className="form-text custom-label">
                    Скан договора аренды помещения (офиса)*
                  </label>
                  <div className="input-group mb-3">
                    <input
                        disabled = {!isAvailabilityContract()}
                        onChange={(e) => {
                        if (e.target.files && e.target.files.length > 0) {
                            getDataEvent.setFile(e.target.files[0], setSkanContractRent);
                        }
                        else{
                            getDataEvent.setFile(null, setSkanContractRent);
                        }
                      }}
                      name="SkanContractRent"
                      className="form-control"
                      type="file"
                      placeholder="Выберите или перетащите файл"
                    />
                    <span className="input-group-text">
                      <i className="fas fa-upload"></i>
                    </span>
                  </div>
                </div>
                <div className="col-2">
                  <input
                    disabled = {!isSkanContractRent()}
                    name="AvailabilityContract"
                    onClick={(e) => {
                      const isChecked = (e.target as HTMLInputElement).checked;
                      getDataEvent.setContract(isChecked, setAvailabilityContract);
                    }}
                    className="form-check-input custom-checkbox"
                    type="checkbox"
                  />
                  <label className="form-text custom-label-checkbox">Нет договора</label>
                </div>
              </div>
              {requesitesForm.length === 0 && (
                 <button
                   className="btn btn-primary custom-button-right"
                   onClick={() => getDataEvent.getRequesitesForm(setrequesitesForm)}
                   disabled={!isValidForm()}
                 >
                   Далее
                 </button>
               )}
            {requesitesForm.map((item, index) => (
              <div key={index}>{item}</div>
            ))}

            {requesitesForm.length > 0 && (
              <div className="row">
                <div className="col-3">
            <p className='button-add-requesites'
               onClick={() => getDataEvent.getRequesitesForm(setrequesitesForm)}>
                <i className="button-add-requesites">
                <FontAwesomeIcon className="custom-picture" icon={faPlus}/>Добавить ещё один банк</i></p>
               </div>
               {requesitesForm.length > 1 && (
               <div className="col-3">
            <p className='button-remove-requesites'
               onClick={() => getDataEvent.deleteRequesitesForm(setrequesitesForm)}>
                <i className="button-remove-requesites">
                  <FontAwesomeIcon className="custom-picture" icon={faMinus} />Удалить банк</i></p>
            </div>)}
            </div>
               )}
            </form>
        </div>
    )
}