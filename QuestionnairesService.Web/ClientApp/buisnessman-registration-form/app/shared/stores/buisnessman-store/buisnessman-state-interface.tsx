export interface BuisnessmanState {
    buisnessman: {
      buisnessman: {
        inn: string;
        fullName: string;
        shortName: string;
        registrationNumber: string;
        registrationDate: undefined | Date;
        SkanInn: undefined | File;
        SkanOgrnip: undefined | File;
        SkanResponseEgrip: undefined | File;
        SkanContractRent: undefined | File;
        AvailabilityContract: boolean;
        requesitesBanks: {
          bin: string;
          nameBankBranch: string;
          correspondentAccount: string;
        };
      };
    };
  }