<template>
    <div>
        <div id="spinner" class="spinner-wrap hide"><div class="sprite-spinner"></div></div>
        <router-view>
        </router-view>
    </div>
</template>
<script>
    export default {
        name: 'app'
    }
</script>
<style lang="scss">
    .hide {
        display: none !important;
    }
        
    $spinner-color:               #6599e7;
    $spinner-background-color:    #000000;

    body > .spinner-wrap {
        width: 100%;
        height: 100%;
        min-height: 100vh;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .sprite-spinner {
        overflow: hidden;
        position: relative;
        display: inline-block;
        text-align: left;
    }

    .spinner-wrap {
        position: fixed;
        top: 0;
        left: 0;
        z-index: 10;
        display: flex;
        width: 100%;
        height: 100%;
        min-height: 100vh;
        text-align: center;
        margin: 0 auto;
        align-items: center;
        justify-content: center;
        -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";
        filter: alpha(opacity=50);
        -moz-opacity: 0.5;
        -khtml-opacity: 0.5;
        opacity: 0.5;
        background: $spinner-background-color;
        z-index: 99999;
    }

    .loading-spinner {
        position: relative;
        overflow: hidden;
    }

    .loading-loaded {
        display: none;
    }

    .loading-fixed {
        position: fixed;
        z-index: 10000;
    }

    .sprite-spinner,
    .sprite-spinner:after {
        border-radius: 50%;
        width: 10em;
        height: 10em;
    }

    .sprite-spinner {
        margin: 60px auto;
        font-size: 10px;
        position: relative;
        text-indent: -9999em;
        border-top: 1.1em solid rgba($spinner-color, 0.2);
        border-right: 1.1em solid rgba($spinner-color, 0.2);
        border-bottom: 1.1em solid rgba($spinner-color, 0.2);
        border-left: 1.1em solid $spinner-color;
        -webkit-transform: translateZ(0);
        -ms-transform: translateZ(0);
        transform: translateZ(0);
        -webkit-animation: load8 1.1s infinite linear;
        animation: load8 1.1s infinite linear;
    }

    @-webkit-keyframes load8 {
        0% {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        100% {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
    }

    @keyframes load8 {
        0% {
            -webkit-transform: rotate(0deg);
            transform: rotate(0deg);
        }

        100% {
            -webkit-transform: rotate(360deg);
            transform: rotate(360deg);
        }
    }
</style>
