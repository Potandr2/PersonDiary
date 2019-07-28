import { LifeEvent } from '../models/lifeevent';

class Person {
  id: number;
  name: string;
  surname: string;
  lifeevents: LifeEvent[];
  hasfile: boolean;
}

export { Person}
