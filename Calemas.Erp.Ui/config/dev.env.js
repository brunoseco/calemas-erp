var merge = require('webpack-merge')
var prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
    NODE_ENV: '"development"',

    ENDPOINT_DEFAULT: '"http://localhost:56307/api"',
    ENDPOINT_SSO: '"http://localhost:4000/connect"',
    LOCATION_URL: '"http://localhost:8080"',

})
