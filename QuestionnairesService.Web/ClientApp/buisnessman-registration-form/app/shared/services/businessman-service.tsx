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

  
}