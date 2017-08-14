<template>
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-sm-6">
                <full-calendar :events="events" locale="pt" :weekNames="weekNames" :monthNames="monthNames"></full-calendar>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-12 col-lg-6">
                        <div class="card card-inverse card-primary">
                            <div class="card-block">
                                <div class="h4 m-0">89.9%</div> <div>Lorem ipsum...</div>
                                <div class="progress progress-white progress-xs my-1">
                                    <div role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar" style="width: 25%;"></div>
                                </div>
                                <small class="text-muted">Lorem ipsum dolor sit amet enim.</small>
                            </div>
                        </div>
                    </div> <div class="col-sm-12 col-lg-6">
                        <div class="card card-inverse card-warning">
                            <div class="card-block">
                                <div class="h4 m-0">12.124</div> <div>Lorem ipsum...</div> <div class="progress progress-white progress-xs my-1">
                                    <div role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar" style="width: 25%;"></div>
                                </div>
                                <small class="text-muted">Lorem ipsum dolor sit amet enim.</small>
                            </div>
                        </div>
                    </div> <div class="col-sm-12 col-lg-6">
                        <div class="card card-inverse card-danger">
                            <div class="card-block">
                                <div class="h4 m-0">$98.111,00</div> <div>Lorem ipsum...</div> <div class="progress progress-white progress-xs my-1">
                                    <div role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar" style="width: 25%;"></div>
                                </div>
                                <small class="text-muted">Lorem ipsum dolor sit amet enim.</small>
                            </div>
                        </div>
                    </div> <div class="col-sm-12 col-lg-6">
                        <div class="card card-inverse card-info">
                            <div class="card-block">
                                <div class="h4 m-0">2 TB</div> <div>Lorem ipsum...</div> <div class="progress progress-white progress-xs my-1">
                                    <div role="progressbar" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100" class="progress-bar" style="width: 25%;"></div>
                                </div>
                                <small class="text-muted">Lorem ipsum dolor sit amet enim.</small>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <div class="social-box facebook">
                            <i class="fa fa-line-chart"></i>
                            <ul><li><strong>89k</strong> <span>friends</span></li> <li><strong>459</strong> <span>feeds</span></li></ul>
                        </div>
                    </div> <div class="col-md-3 col-sm-6">
                        <div class="social-box twitter">
                            <i class="fa fa-pie-chart"></i> <ul>
                                <li>
                                    <strong>973k</strong>
                                    <span>followers</span>
                                </li>
                                <li><strong>1.792</strong> <span>tweets</span></li>
                            </ul>
                        </div>
                    </div> <div class="col-md-3 col-sm-6">
                        <div class="social-box linkedin">
                            <i class="fa fa-area-chart"></i> <ul>
                                <li><strong>500+</strong> <span>contacts</span></li>
                                <li>
                                    <strong>292</strong>
                                    <span>feeds</span>
                                </li>
                            </ul>
                        </div>
                    </div> <div class="col-md-3 col-sm-6">
                        <div class="social-box google-plus">
                            <i class="fa fa-archive"></i> <ul>
                                <li>
                                    <strong>894</strong>
                                    <span>followers</span>
                                </li>
                                <li><strong>92</strong> <span>circles</span></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</template>
<script>

    import fullCalendar from 'vue-fullcalendar'

    export default {
        name: 'dashboard',
        components: { fullCalendar },

        data() {
            return {
                weekNames: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"],
                monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
                events: []
            }
        },

    }
</script>
