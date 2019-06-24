interface Person {
  Id: number;
  Name: string;
  Surname: string;
  LifeEvents: LifeEvent[];
}
interface LifeEvent {
  Id: number;
  Name: string;
  EventDate: Date;
  PersonId: number;
}

export { Person, LifeEvent }
