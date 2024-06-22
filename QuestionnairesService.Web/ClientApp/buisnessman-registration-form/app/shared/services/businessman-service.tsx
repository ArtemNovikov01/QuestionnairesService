import { GetInfoByInn } from "../models/formModels/getInfoByInnModel";

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
        throw new Error(errorText);
      }

      const data: GetInfoByInn = await response.json();
      console.log(data);
      console.log(data.registrationDate);
      return data;
  }
}