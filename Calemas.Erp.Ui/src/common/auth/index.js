import Cache from '../cache'
import Global from '../global'
import { Api } from '../api'

export default {

    state: 'STATE_AUTH',

    authorize_url: Global.SSO_END_POINT + '/authorize',
    endsession_url: Global.SSO_END_POINT + '/endsession',
    redirect_uri: Global.SSO_REDIRECT_LOGIN_URL,
    post_logout_redirect_uri: Global.SSO_REDIRECT_LOGOUT_URL,

    client_id: Global.SSO_CLIENT_ID,
    response_type: Global.SSO_RESPONSE_TYPE,
    scope: Global.SSO_SCOPE,

    getToken: function () {
        return Cache.get(Global.ID_TOKEN);
    },

    getState: function () {
        return Cache.get(this.state);
    },

    logged: function () {
        return Cache.get(Global.ID_TOKEN);
    },

    login: function () {

        Cache.add(this.state, Date.now());

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
        var api = new Api("userinfo", Global.SSO_END_POINT);
        api.hasDefaultFilters = false;
        api.get().then(a => { console.log(a) }, b => { console.log(b) });
    },

    logout: function () {

        var url = this.endsession_url + "?" +
            "id_token_hint=" + this.getToken() + "&" +
            "post_logout_redirect_uri=" + encodeURIComponent(this.post_logout_redirect_uri) + "&" +
            "state=" + encodeURIComponent(this.getState());

        Cache.remove(Global.ACCESS_TOKEN);
        Cache.remove(Global.ID_TOKEN);

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

        Cache.add(Global.ACCESS_TOKEN, result.access_token);
        Cache.add(Global.ID_TOKEN, result.id_token);

        setTimeout(() => { window.location = '/'; }, 1000)

    }

}