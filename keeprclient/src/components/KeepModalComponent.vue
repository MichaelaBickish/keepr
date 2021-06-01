<template class="Keep-Modal-Component">
  <div class="modal" id="keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-12 col-md-6">
                <img src="https://images.ctfassets.net/hrltx12pl8hq/3MbF54EhWUhsXunc5Keueb/60774fbbff86e6bf6776f1e17a8016b4/04-nature_721703848.jpg?fit=fill&w=480&h=270" class="keep-img">
              </div>
              <div class="col-12 col-md-6">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
                <p>views shares keeps</p>
                <h1>keep title</h1>
                <p>keep description</p>
                <p>add to vault | delete keep | creator</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- <div class="modal-body" id="keep-modal">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          .col-md-4
        </div>
        <div class="col-md-4 ml-auto">
          .col-md-4 .ml-auto
        </div>
      </div>
      <div class="row">
        <div class="col-md-3 ml-auto">
          .col-md-3 .ml-auto
        </div>
        <div class="col-md-2 ml-auto">
          .col-md-2 .ml-auto
        </div>
      </div>
      <div class="row">
        <div class="col-md-6 ml-auto">
          .col-md-6 .ml-auto
        </div>
      </div>
      <div class="row">
        <div class="col-sm-9">
          Level 1: .col-sm-9
          <div class="row">
            <div class="col-8 col-sm-6">
              Level 2: .col-8 .col-sm-6
            </div>
            <div class="col-4 col-sm-6">
              Level 2: .col-4 .col-sm-6
            </div>
          </div>
        </div>
      </div>
    </div>
  </div> -->
</template>

<script>
export default {
  name: 'KeepModalComponent',
  // TODO ? - props for active keep on modal?
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.keep-img{
  max-width: 100%;
}
</style>
