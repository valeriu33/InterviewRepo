export class Company {
  id: number;
  name: string;
  shareholders: Shareholder[];
}

export class Shareholder {
  name: string;
  amountOfMoney: number;
}
