import { CreateRequesitesBank } from "./createRequesitesBank";

export class CreateBuisnessman{
    public inn!: string;
    public fullName?: string;
    public shortName?: string;
    public registrationNumber!: string;
    public registrationDate?: Date;
    public SkanInn?: File;
    public SkanOgrnip?: File;
    public SkanResponseEgrip?: File;
    public SkanContractRent?: File;
    public AvailabilityContract!: boolean
    public requesitesBanks!:CreateRequesitesBank[]
}