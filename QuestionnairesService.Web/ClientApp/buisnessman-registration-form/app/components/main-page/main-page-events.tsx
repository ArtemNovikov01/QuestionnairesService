import { BuisnessmanType } from "@/app/shared/models/enums/BuisnessmanType";


export default function MainEvents() {
  function selectType(type: BuisnessmanType) {
    console.log(`Выбран тип: ${type}`);
  }

  return selectType;
}