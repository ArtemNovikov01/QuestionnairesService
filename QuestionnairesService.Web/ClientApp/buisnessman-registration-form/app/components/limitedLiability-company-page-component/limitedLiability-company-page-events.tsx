import { GetInfoByInn } from "@/app/shared/models/formModels/getInfoByInnModel";
import { BusinessmanService } from "@/app/shared/services/businessman-service";

const service = new BusinessmanService()

export class LimitedLiabilityCompanyEvents {
    async getData(inn: string, formElements: React.Dispatch<React.SetStateAction<GetInfoByInn>>){
        if(inn.length === 10){
            const data = await service.getDataByInn(inn);
            const registrationDate = new Date(data.registrationDate);
            registrationDate.setDate(registrationDate.getDate() + 1);
            formElements(prevState => ({
                ...prevState,
                fullName: data.fullName,
                shortName: data.shortName,
                registrationNumber: data.registrationNumber,
                registrationDate: registrationDate
            }));
        }
    }
}