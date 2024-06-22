import "./individual-entrepreneur-page.css"

export default function IndividualEntrepreneur(){
    return(
        <div className="container-fluid">
            <p className="custom-paragraph">Индивидуальный предприниматель (ИП)</p>
            <form className="col-12">
                <div className="row"> 
                    <div className="col-2">
                        <label className="form-text custom-label">ИНН*</label>
                        <input className="form-control" placeholder="xxxxxxxxxx"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан ИНН*</label>
                        <div className="input-group mb-3"> 
                        <input className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-2">
                        <label className="form-text custom-label">ОГРНИП*</label>
                        <input className="form-control" placeholder="xxxxxxxxxxxxxxx"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан ОГРНИП*</label>
                        <div className="input-group mb-3"> 
                        <input className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                </div>
                <div className="row"> 
                    <div className="col-2">
                        <label className="form-text custom-label">Дата регистрации*</label>
                        <input className="form-control" placeholder="xxxxxxxxxx"/>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан выписки из ЕГРИП (не старше 3 месяцев)*</label>
                        <div className="input-group mb-3"> 
                        <input className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                        <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-4">
                        <label className="form-text custom-label">Скан договора аренды помещения (офиса)*</label>
                        <div className="input-group mb-3"> 
                            <input className="form-control" type="file" placeholder="Выберите или перетащите файл"/>
                            <span className="input-group-text"><i className="fas fa-upload"></i></span>
                        </div>
                    </div>
                    <div className="col-2">
                        <input className="form-check-input custom-checkbox" type="checkbox"/>
                        <label className="form-text custom-label-checkbox">Нет договора</label>
                    </div>
                </div>
            </form>
        </div>
    )
}