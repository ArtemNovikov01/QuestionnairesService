import { BusinessmanService } from "@/app/shared/services/businessman-service";
import { Buisnessman } from "@/app/shared/models/form-models/buisnessmanModel";

const service = new BusinessmanService()
export class IndividualCompanyEvents {
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
        
    async createBuisnessman(buisnessman:Buisnessman){
        await service.createBuisnessman(buisnessman);
    }
}