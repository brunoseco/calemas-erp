import Cache from '../cache'
import Cookie from '../cookie'
import Global from '../global'
import { Api } from '../api'

export default {

    authorize_url: Global.SSO_END_POINT + '/authorize',
    endsession_url: Global.SSO_END_POINT + '/endsession',
    redirect_uri: Global.SSO_REDIRECT_LOGIN_URL,
    post_logout_redirect_uri: Global.SSO_REDIRECT_LOGOUT_URL,

    client_id: Global.SSO_CLIENT_ID,
    response_type: Global.SSO_RESPONSE_TYPE,
    scope: Global.SSO_SCOPE,

    getToken: function () {
        return Cookie.get(Global.ID_TOKEN);
    },

    getState: function () {
        return Cookie.get(Global.ID_STATE);
    },

    logged: function () {
        return Cookie.get(Global.ID_TOKEN);
    },

    login: function () {

        Cookie.add(Global.ID_STATE, Date.now());

        var url = this.authorize_url + "?" +
            "client_id=" + encodeURIComponent(this.client_id) + "&" +
            "redirect_uri=" + encodeURIComponent(this.redirect_uri) + "&" +
            "response_type=" + encodeURIComponent(this.response_type) + "&" +
            "scope=" + encodeURIComponent(this.scope) + "&" +
            "state=" + encodeURIComponent(this.getState()) + "&" +
            "nonce=xyz";

        window.location = url;
    },

    userinfo: function () {
        var _user = JSON.parse(Cache.get(Global.USER_INFO));
        return _user;
    },

    logout: function () {

        var url = this.endsession_url + "?" +
            "id_token_hint=" + this.getToken() + "&" +
            "post_logout_redirect_uri=" + encodeURIComponent(this.post_logout_redirect_uri) + "&" +
            "state=" + encodeURIComponent(this.getState());

        Cookie.remove(Global.ACCESS_TOKEN);
        Cookie.remove(Global.ID_TOKEN);
        Cache.remove(Global.USER_INFO);

        window.location = url;
    },

    verifyLogin: function () {

        if (window.location.href.indexOf("access_token") < 0)
            window.location = '/';

        var itens = window.location.hash.split('?');
        var result = itens[1].split('&').reduce(function (result, item) {
            var parts = item.split('=');
            result[parts[0]] = parts[1];
            return result;
        }, {});

        Cookie.add(Global.ACCESS_TOKEN, result.access_token, result.expires_in);
        Cookie.add(Global.ID_TOKEN, result.id_token, result.expires_in);

        var api = new Api("userinfo", Global.SSO_END_POINT);
        api.hasDefaultFilters = false;
        api.get().then(response => {
            Cache.add(Global.USER_INFO, JSON.stringify(response));
            setTimeout(() => { window.location = '/'; }, 500);
        });
    }

}