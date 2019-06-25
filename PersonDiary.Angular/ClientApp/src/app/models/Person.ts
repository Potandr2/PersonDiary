import { LifeEvent } from '../models/lifeevent';

interface Person {
  id: number;
  name: string;
  surname: string;
  lifeevents: LifeEvent[];
}

export { Person}
