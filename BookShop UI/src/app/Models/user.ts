export class User {
    Id?: number;
	Email!: string;
	Firstname!: string;
	Lastname!: string;
	Roleid!: number;
	Role?: string;
	Password?: string;
}


// if in C# public string FirstName then when it return json it will contain "firstName" proparty.