export class FinancialResultModel {

    constructor(public monthNumber: string,
                public capitalPartOfInstallment: string,
                public interestPartOfInstallment: string,
                public capitalToRepay: string,
                public interestToRepay: string
    ) { }
}
