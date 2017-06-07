import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Cache from '../cache'
import Constants from '../global'

Vue.use(VueAxios, axios)

export function Api(o) {

    this.Resourse = o;

    this.DefaultFilter = {
        PageSize: 50,
        PageIndex: 0,
        IsPaginate: true,
        QueryOptimizerBehavior: "",
    };

    this.EnableLoading = true;
    this.EnableErrorMessage = true;
    this.Filter = {};
    this.Cache = false;
    this.LastAction = "none";
    this.Url = "";

    this.SuccessHandle = function (data) { return data; };
    this.ErrorHandle = function (err) { return err; };

    this.Get = _get;
    this.GetDetails = _getDetails;
    this.Post = _post;
    this.Put = _put;
    this.Delete = _delete;
    this.DataItem = _dataitem;
    this.GetDataListCustom = _getDataListCustom;
    this.GetDataCustom = _getDataCustom;
    this.GetMethodCustom = _getMethodCustom;

    var self = this;


    function _post(data) {

        showLoading();

        self.LastAction = "post";
        self.Url = makeUri();

        return axios
            .post(self.Url, data)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _put(data) {

        showLoading();

        self.LastAction = "put";
        self.Url = makeUri();

        return axios
            .put(self.Url, data)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _delete() {

        showLoading();

        self.LastAction = "delete";
        self.Url = makeDeleteBaseUrl();

        return axios
            .delete(self.Url)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _get() {

        showLoading();

        self.LastAction = "get";
        self.Url = makeGetBaseUrl();

        if (isOffline())
            return loadFromCache();

        return axios
            .get(self.Url)
            .then(res => { handleSuccess(res.data); return res.data; }, err => { handleError(err); return err; });
    }

    function _getMethodCustom(method) {

        showLoading();

        self.LastAction = "get";
        self.Url = makeGetCustomMethodBaseUrl(method);

        if (isOffline())
            return loadFromCache();

        return axios
            .get(self.Url)
            .then(handleSuccess, handleError);
    }

    function _getDataListCustom() {
        return _getMethodCustom("GetDataListCustom");
    }

    function _getDetails() {
        return _getMethodCustom("GetDetails");
    }

    function _getDataCustom() {
        return _getMethodCustom("GetDataCustom");
    }

    function _dataitem() {
        return _getMethodCustom("GetDataItem");
    }

    function makeGetBaseUrl() {
        return String.format("{0}/{1}", makeUri(), queryStringFilter());
    }

    function makeGetCustomMethodBaseUrl(method) {
        return String.format("{0}/{1}/{2}", makeUri(), method, queryStringFilter());
    }

    function makeDeleteBaseUrl() {
        return String.format("{0}/?{1}", makeUri(), Object.$httpParamSerializer(self.Filter));
    }

    function makeUri() {
        return String.format("{0}/{1}", makeEndPont(), self.Resourse)
    }

    function makeEndPont() {

        if (!self.EndPoint)
            return Constants.END_POINT_DEFAULT;

        return Constants[self.EndPoint];
    }

    function queryStringFilter() {

        if (self.Filter.OrderFields !== undefined) {
            self.Filter.IsOrderByDynamic = true;
            if (self.Filter.OrderByType === undefined)
                self.Filter.OrderByType = 1;
        }

        var filter = Object.assign({}, self.DefaultFilter, self.Filter);

        if (self.Filter.Id !== undefined)
            return String.format("{0}?{1}", self.Filter.Id, Object.$httpParamSerializer(filter));

        return String.format("?{0}", Object.$httpParamSerializer(filter));
    }

    function handleSuccess(response) {
        hideLoading();
        addCache(response.data);
        return self.SuccessHandle(response.data);
    }

    function handleError(err) {
        hideLoading();
        return self.ErrorHandle(err.data);
    }


    function showLoading() {
        // if (self.EnableLoading)
        //     Loading.show();
    }

    function hideLoading() {
        // if (self.EnableLoading)
        //     Loading.hide();
    }

    function addCache(data) {

        if (!self.Cache)
            return;

        if (self.Url == "")
            return;

        if (self.LastAction == "get") {
            if (data.Data != null || (data.DataList != null && data.DataList.length > 0)) {
                data = JSON.stringify(data);
                Cache.Add(self.Url, data)
            }
        }
    }

    function loadFromCache() {

        if (!self.Cache)
            return;

        hideLoading();

        var data = Cache.Get(self.Url);
        data = JSON.parse(data);

        if (data != null)
            self.SuccessHandle(data);
    }

    function isOffline() {
        if (navigator.network != null) {
            var isOffline = !navigator.onLine;
            return isOffline;
        }
        return false;
    }

    String.format = function () {
        var theString = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
            theString = theString.replace(regEx, arguments[i]);
        }
        return theString;
    }

    Object.$httpParamSerializer = function () {
        var obj = arguments[0];
        return Object.entries(obj).map(([key, val]) => `${key}=${val}`).join('&')
    }

}

