<template>
    <div>
        <div id="spinner" class="spinner-wrap hide"><div class="sprite-spinner"></div></div>
        <router-view>
        </router-view>
    </div>
</template>
<script>
    export default {
        name: 'app',
    }
</script>