export class AppRoute {
    private static readonly prefix: string = "/#/";

    //Without prefix
    static readonly home: string = "home";
    static readonly login: string = "account/login";
    static readonly register: string = "account/register";
    static readonly error: string = "error";

    //With prefix
    static readonly homeP: string = AppRoute.prefix + AppRoute.home;
    static readonly loginP: string = AppRoute.prefix + AppRoute.login;
    static readonly registerP: string = AppRoute.prefix + AppRoute.register;
    static readonly errorP: string = AppRoute.prefix + AppRoute.error;
}