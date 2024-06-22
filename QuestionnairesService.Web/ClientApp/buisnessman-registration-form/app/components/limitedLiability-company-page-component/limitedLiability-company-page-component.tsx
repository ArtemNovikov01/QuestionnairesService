import { useState } from "react";
import { LimitedLiabilityCompanyEvents } from "./limitedLiability-company-page-events"
import { GetInfoByInn } from "@/app/shared/models/formModels/getInfoByInnModel";

const getDataEvent = new LimitedLiabilityCompanyEvents()

export default function LimitedLiabilityCompany(){
    const [formValues, setFormValues] = useState<GetInfoByInn>({
        inn: '',
        fullName: '',
        shortName: '',
        registrationNumber: 0,
        registrationDate: new Date
      });

    return(
        <div className="container-fluid">
            <p className="custom-paragraph">Общество с ограниченной ответственностью (ООО)</p>
            <form className="col-12">
                <div className="row">
                    <div className="col-6">
                        <label className="form-text custom-label">Наименование полное*</label>
                        <input name="fullName" value={formValues.fullName} className="form-control" placeholder="ООО &laquo;Московская промышленная компания&raquo;"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Наименование сокращенное*</label>
                        <input name="shortName" value={formValues.shortName} className="form-control" placeholder="ООО &laquo;МПК&raquo;"/>
                    </div>
                    <div className="col-2">
                        <label className="form-text custom-label">Дата регистрации*</label>
                        <input name="dateRegistration" value={formValues.registrationDate.toISOString().slice(0, 10)}  className="form-control" type="date" placeholder="xxxxxxxxxx"/>
                    </div>
                </div>
                <div className="row"> 
                    <div className="col-2">
                        <label className="form-text custom-label">ИНН*</label>
                        <input name="Inn" onChange={(e) => getDataEvent.getData(e.target.value, setFormValues)} className="form-control" placeholder="xxxxxxxxxx"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан ИНН*</label>
                        <div className="input-group mb-3"> 
                        <input name="SkanInn" className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-2">
                        <label className="form-text custom-label">ОГРН*</label>
                        <input name="Ogrnip" value={formValues.registrationNumber} className="form-control" placeholder="xxxxxxxxxxxxxxx"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан ОГРН*</label>
                        <div className="input-group mb-3"> 
                        <input name="SkanOgrnip" className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                </div>
                <div className="row"> 
                    <div className="col-4">
                        <label className="form-text custom-label">Скан выписки из ЕГРИП (не старше 3 месяцев)*</label>
                        <div className="input-group mb-3"> 
                        <input name="SkanResponseEgrip" className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан договора аренды помещения (офиса)*</label>
                        <div className="input-group mb-3"> 
                            <input name="SkanContractRent" className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                            <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-2">
                        <input name="HasContract" className="form-check-input custom-checkbox" type="checkbox"/>
                        <label className="form-text custom-label-checkbox">Нет договора</label>
                    </div>
                </div>
            </form>
        </div>
    )
}