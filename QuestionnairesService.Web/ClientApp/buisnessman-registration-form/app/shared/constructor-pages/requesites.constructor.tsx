import Requesites from "@/app/components/requesites-page-component/requesites-page.component";

export class RequesitesConstructor {
    getRequesitesForm(setSelectedComponent: React.Dispatch<React.SetStateAction<React.ReactNode[]>>) {
        setSelectedComponent((prevState) => {
          console.log(prevState.length)
          const newState = [...prevState, <Requesites index={prevState.length}/>];
          return newState;
        });
    }

    //ToDo разобраться почему возвращается index = 0
    //ToDo Доработать валидацию файлов на сервере
    //ToDo Сделать так чтобы на сервере была проверка галочки или файла
    
    deleteRequesitesForm(
        setSelectedComponent: React.Dispatch<React.SetStateAction<React.ReactNode[]>>
      ): number{
        let indexToRemove = 0;
        setSelectedComponent((prevState) => {
          if (prevState.length === 0) {
            return prevState;
          } else if (prevState.length === 1) {
            indexToRemove = 0;
            return [];
          } else {
            indexToRemove = prevState.length - 1;
            return prevState.filter((_, i) => i !== indexToRemove);
          }
        });
        return indexToRemove;
      };
}