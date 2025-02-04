import { GetInfoByInn } from "@/app/shared/models/form-models/getInfoByInnModel";
import { BusinessmanService } from "@/app/shared/services/businessman-service";
import { Buisnessman } from "@/app/shared/models/form-models/buisnessmanModel";



const service = new BusinessmanService()
export class LimitedLiabilityCompanyEvents {
    public registrationDate?:Date;

    setFile(file: File | null, fileFromForm: React.Dispatch<React.SetStateAction<File | null>>) {
      if (file) {
        fileFromForm(file);
      }
      else{
        fileFromForm(file);
      }
    }

    setContract(mark: boolean, markFromForm: React.Dispatch<React.SetStateAction<boolean>>) {
      markFromForm(mark);
    }

    async getData(inn: string, formElements: React.Dispatch<React.SetStateAction<GetInfoByInn>>){
        if (/^\d{10}$/.test(inn)){
            const data = await service.getDataByInn(inn);

            if(data.registrationDate){
                this.registrationDate = new Date(data.registrationDate);
                this.registrationDate.setDate(this.registrationDate.getDate() + 1);
            }
            else{
                this.registrationDate = undefined;
            }

            formElements(prevState => ({
                ...prevState,
                inn: data.inn,
                fullName: data.fullName,
                shortName: data.shortName,
                registrationNumber: data.registrationNumber,
                registrationDate: this.registrationDate,
                errorMessage: data.errorMessage
            }));
        }
        if(!parseInt(inn)){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'ИНН должен состоять только из цифр'
            }));
        }
        if(inn.length < 10){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'ИНН должен состоять из 10 символов'
            }));
        }
        if(inn.length > 10){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'ИНН должен состоять из 10 символов'
            }));
        }
        if(inn.length < 10 && !parseInt(inn)){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'ИНН должен состоять только из цифр. ИНН должен состоять из 10 символов'
            }));
        }
        if(inn.length === 0){
            formElements(prevState => ({
                ...prevState,
                errorMessage: ''
            }));
        }
    }
      
    async createBuisnessman(buisnessman:Buisnessman){
        await service.createBuisnessman(buisnessman);
    }
      
}