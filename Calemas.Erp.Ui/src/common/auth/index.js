import Cache from '../cache'

export default {

    token: 'TOKEN_AUTH',

    authorize_url: 'http://localhost:4000/connect/authorize',
    endsession_url: 'http://localhost:4000/connect/endsession',
    redirect_uri: 'http://localhost:8080/#/authorized/?',
    client_id: 'ssocalemas',
    response_type: 'token',
    scope: 'calemas',
    state: Date.now() + "" + Math.random(),

    getToken: function () {
        return Cache.get(this.token);
    },

    logged: function () {

    },

    login: function () {

        localStorage["state"] = this.state;

        var url = this.authorize_url + "?" +
            "client_id=" + encodeURIComponent(this.client_id) + "&" +
            "redirect_uri=" + encodeURIComponent(this.redirect_uri) + "&" +
            "response_type=" + encodeURIComponent(this.response_type) + "&" +
            "scope=" + encodeURIComponent(this.scope) + "&" +
            "state=" + encodeURIComponent(this.state);

        window.location = url;

    },

    logout: function () {

        var post_logout_redirect_uri = 'http://localhost:8080';
        console.log(this.getToken())
        console.log(encodeURIComponent(this.getToken()))
        var url = this.endsession_url + "?" +
            "logoutId=" + this.getToken() + "&" +
            "post_logout_redirect_uri=" + encodeURIComponent(post_logout_redirect_uri);

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

        Cache.add('TOKEN_AUTH', result.access_token);
        setTimeout(() => { window.location = '/'; }, 1000)

    }

}