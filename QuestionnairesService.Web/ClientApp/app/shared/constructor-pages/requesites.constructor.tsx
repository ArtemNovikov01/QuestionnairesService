import Requesites from "@/app/components/requesites-page-component/requesites-page.component";

export class RequesitesConstructor {
    getRequesitesForm(setSelectedComponent: React.Dispatch<React.SetStateAction<React.ReactNode[]>>) {
        setSelectedComponent((prevState) => {
          const newState = [...prevState, <Requesites key={prevState.length} index={prevState.length}/>];
          return newState;
        });
    }
    
    async deleteRequesitesForm(
        setSelectedComponent: React.Dispatch<React.SetStateAction<React.ReactNode[]>>
      ): Promise<number>{
        let indexToRemove = 0;
        await setSelectedComponent((prevState) => {
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
