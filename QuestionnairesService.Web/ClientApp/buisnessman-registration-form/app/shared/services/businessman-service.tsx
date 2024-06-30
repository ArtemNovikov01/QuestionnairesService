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
//ToDo Разобраться почему форма не отправляется на сервер
async createBuisnessman(newBuisnessman: Buisnessman) {
  console.log(newBuisnessman);
  const formData = new FormData();
  formData.append('SkanINN', newBuisnessman.SkanInn!);
  formData.append('SkanRegistrationNumber', newBuisnessman.SkanRegistrationNumber!);
  formData.append('SkanExtractFromTax', newBuisnessman.SkanExtractFromTax!);
  formData.append('SkanContractRent', newBuisnessman.SkanContractRent!);
  formData.append('BuisnessmanInfo', JSON.stringify(newBuisnessman.buisnessmanInfo));

  const entries = Array.from(formData.entries());
entries.forEach(([key, value]) => {
  console.log(`${key}: ${value}`);
});

  const response = await fetch(this.baseApi + 'createBusinessman', {
    method: 'POST',
    body: formData,
    // headers: {
    //   'Content-Type': 'multipart/form-data'
    // }
  });

  return await response.json();
}


  
}