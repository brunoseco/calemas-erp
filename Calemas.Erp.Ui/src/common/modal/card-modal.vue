<template>
    <transition :name="transition" mode="in-out" appear :appear-active-class="enterClass" :enter-active-class="enterClass" :leave-active-class="leaveClass" @beforeEnter="beforeEnter" @afterEnter="afterEnter" @beforeLeave="beforeLeave" @afterLeave="afterLeave">
        <div :class="classes" v-if="show">
            <div class="modal-background" @click="deactive"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">{{ title }}</p>
                    <button class="delete" @click="deactive"></button>
                </header>
                <section class="modal-card-body">
                    <slot name="content"></slot>
                </section>
                <footer class="modal-card-foot">
                    <template v-if="!hasFooterSlot">
                        <a class="button" @click="deactive">{{ cancelText }}</a>
                        <a class="button is-success" @click="ok">{{ okText }}</a>
                    </template>                    
                    <slot name="footer"></slot>
                </footer>
            </div>
        </div>
    </transition>
</template>

<script>
import BaseModal from './base-modal'

export default {
    mixins: [BaseModal],

    props: {
        title: {
            type: String
        },
        okText: {
            type: String,
            default: 'Salvar'
        },
        cancelText: {
            type: String,
            default: 'Fechar'
        }
    },

    computed: {
        classes() {
            return ['modal', 'animated', 'is-active']
        }
    },

    methods: {
        ok() {
            this.$emit('ok')
        },

        cancel() {
            this.deactive()
            this.$emit('cancel')
        },
    }
}
</script>
