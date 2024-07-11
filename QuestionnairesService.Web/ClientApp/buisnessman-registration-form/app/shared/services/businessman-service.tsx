import { Buisnessman } from "../models/form-models/buisnessmanModel";
import { GetInfoByBin } from "../models/form-models/getInfoByBinModel";
import { GetInfoByInn } from "../models/form-models/getInfoByInnModel";

export class BusinessmanService {
  baseApi: string = "http://localhost:5092/api/Businessman/";

  async getDataByInn(inn: string): Promise<GetInfoByInn> {

      const response = await fetch(this.baseApi + 'getInfoByInn', {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ inn }),
      });

      if (!response.ok) {
        const errorText = await response.text();
        const parsedData = JSON.parse(errorText);
        
        const data: GetInfoByInn = new GetInfoByInn
        data.inn = '';
        data.fullName = '';
        data.shortName = '';
        data.registrationNumber = '';
        data.registrationDate = undefined;
        data.errorMessage = parsedData.message;
        return data
      }

      const data: GetInfoByInn = await response.json();
      return data;
  }

  async getDataByBin(bin: string): Promise<GetInfoByBin> {

    const response = await fetch(this.baseApi + 'getInfoByBin', {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ bin }),
    });

    if (!response.ok) {
      const errorText = await response.text();
      const parsedData = JSON.parse(errorText);
      
      const data: GetInfoByBin = new GetInfoByBin
      data.bin = '';
      data.nameBankBranch = '';
      data.correspondentAccount = '';
      data.errorMessage = parsedData.message;
      return data
    }

    const data: GetInfoByBin = await response.json();
    return data;
  }


  async createBuisnessman(newBuisnessman: Buisnessman) {
    const formData = new FormData();

    if (newBuisnessman.SkanInn) {
      formData.append('SkanINN', newBuisnessman.SkanInn);
    }
    if (newBuisnessman.SkanRegistrationNumber) {
      formData.append('SkanRegistrationNumber', newBuisnessman.SkanRegistrationNumber);
    }
    if (newBuisnessman.SkanExtractFromTax) {
      formData.append('SkanExtractFromTax', newBuisnessman.SkanExtractFromTax);
    }
    if (newBuisnessman.SkanContractRent) {
      formData.append('SkanContractRent', newBuisnessman.SkanContractRent);
    }

    const { buisnessmanType, fullName, shortName, inn, registrationNumber, registrationDate, availabilityContract, banks } = newBuisnessman.buisnessmanInfo;

    formData.append('BuisnessmanInfo[buisnessmanType]', buisnessmanType.toString());
    formData.append('BuisnessmanInfo[fullName]', fullName || '');
    formData.append('BuisnessmanInfo[shortName]', shortName || '');
    formData.append('BuisnessmanInfo[inn]', inn);
    formData.append('BuisnessmanInfo[registrationNumber]', registrationNumber);
    formData.append('BuisnessmanInfo[registrationDate]', registrationDate || '');
    formData.append('BuisnessmanInfo[availabilityContract]', availabilityContract.toString());

    for (let i = 0; i < banks.length; i++) {
      const { bankCode, branchOfficeName, paymentAccount, correspondentAccount } = banks[i];
      formData.append(`BuisnessmanInfo[banks][${i}][bankCode]`, bankCode);
      formData.append(`BuisnessmanInfo[banks][${i}][branchOfficeName]`, branchOfficeName);
      formData.append(`BuisnessmanInfo[banks][${i}][paymentAccount]`, paymentAccount);
      formData.append(`BuisnessmanInfo[banks][${i}][correspondentAccount]`, correspondentAccount);
    }

    const response = await fetch(this.baseApi + 'createBusinessman', {
      method: 'POST',
      body: formData
    });

    return await response.json();
  }
  
}