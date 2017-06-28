export default {

    END_POINT_DEFAULT: process.env.ENDPOINT_DEFAULT,
    SSO_END_POINT: process.env.ENDPOINT_SSO,

    SSO_REDIRECT_LOGIN_URL: process.env.LOCATION_URL + "/#/authorized/?",
    SSO_REDIRECT_LOGOUT_URL: process.env.LOCATION_URL + "/#/loggedout/?",

    SSO_CLIENT_ID: "ssocalemas",
    SSO_RESPONSE_TYPE: "id_token token",
    SSO_SCOPE: "openid calemas profile email",

    ACCESS_TOKEN: "ACCESS_TOKEN",
    ID_TOKEN: "ID_TOKEN",
    USER_INFO: "USER_INFO",
    ID_STATE: "ID_STATE"

}