
export class Buddy {
    externalId: string;
    email: string;
    cellPhoneNumber: string;
    firstName: string;
    position: number;

    copyFrom(from: Buddy) {
        this.externalId = from.externalId;
        this.cellPhoneNumber = from.cellPhoneNumber;
        this.email = from.email;
        this.position = from.position;
        this.firstName = from.firstName;
        return this;
    }
}
