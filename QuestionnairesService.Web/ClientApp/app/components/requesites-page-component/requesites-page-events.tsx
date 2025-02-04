import { GetInfoByBin } from "@/app/shared/models/form-models/getInfoByBinModel";
import { BusinessmanService } from "@/app/shared/services/businessman-service";
import { CreateRequesitesBank } from "@/app/shared/models/form-models/createRequesitesBank";

const service = new BusinessmanService()

let requesites: CreateRequesitesBank;
export class RequesitesEvents {
    
    getHint(hint: React.Dispatch<React.SetStateAction<boolean>>){
        hint(true);
    }
    removeHint(hint: React.Dispatch<React.SetStateAction<boolean>>){
        hint(false);
    }

    setPaymentAccount(paymentAccount: string,
            paymentAccountFromForm: React.Dispatch<React.SetStateAction<string>>,
            errorMessage: React.Dispatch<React.SetStateAction<string>>){
        if(!parseInt(paymentAccount)){
            errorMessage('Расчётный счёт должен состоять только из цифр')
        }
        if((paymentAccount.length != 20) && !parseInt(paymentAccount)){
            errorMessage('Расчётный счёт должен состоять только из цифр. Длина расчётного счёта должна быть 20 символов')
        }
        if((paymentAccount.length != 20)){
            errorMessage('Длина расчётного счёта должена быть 20 символов')
        }
        if(paymentAccount.length === 0){
            errorMessage('')
        }
        if(paymentAccount.length === 20){
            errorMessage('')
        }
        paymentAccountFromForm(paymentAccount);
    }

    async getData(indexComponent: number, bin: string, paymentAccount:string, formElements: React.Dispatch<React.SetStateAction<GetInfoByBin>>):Promise<CreateRequesitesBank>{
        if (/^\d{9}$/.test(bin)){
            const data = await service.getDataByBin(bin);
            formElements(prevState => ({
                ...prevState,
                bin: data.bin,
                nameBankBranch: data.nameBankBranch,
                correspondentAccount: data.correspondentAccount,
                errorMessage: data.errorMessage
            }));
            requesites = {
                     bankCode: data.bin,
                     branchOfficeName: data.nameBankBranch,
                     correspondentAccount: data.correspondentAccount,
                     paymentAccount: paymentAccount
                   };
            return requesites;
        }
        if(!parseInt(bin)){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'БИК должен состоять только из цифр'
            }));
        }
        if(bin.length < 9 || bin.length > 9){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'БИК должен состоять из 9 символов'
            }));
        }
        if(bin.length < 10 && !parseInt(bin)){
            formElements(prevState => ({
                ...prevState,
                errorMessage: 'БИК должен состоять только из цифр. БИК должен состоять из 10 символов'
            }));
        }
        if(bin.length === 0){
            formElements(prevState => ({
                ...prevState,
                errorMessage: ''
            }));
        }
        requesites ={
            bankCode: '',
            branchOfficeName: '',
            correspondentAccount: '',
            paymentAccount: paymentAccount
        }
        return requesites;
    }
}