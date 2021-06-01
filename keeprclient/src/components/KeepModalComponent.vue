<template class="Keep-Modal-Component">
  <div class="modal" id="keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row justify-content-end">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="row" v-if="state.activeKeep">
              <div class="col-12 col-md-6">
                <img :src="state.activeKeep.img" class="keep-img">
              </div>
              <div class="col-12 col-md-6">
                <!-- row 1 -->
                <div class="row justify-content-center">
                  <div class="col-5">
                    <p class="text-center">
                      <i class="far fa-eye text-primary"></i>  {{ state.activeKeep.views }}
                    </p>
                  </div>
                  <div class="col-5">
                    <p class="text-center">
                      <i class="fas fa-map-pin text-primary"></i>  {{ state.activeKeep.keeps }}
                    </p>
                  </div>
                </div>
                <!-- row 2 -->
                <div class="row flex-column justify-content-center align-items-center">
                  <div class="col-12">
                    <h1 class="text-center">
                      {{ state.activeKeep.name }}
                    </h1>
                  </div>
                  <div class="col-12">
                    <p class="mb-3">
                      {{ state.activeKeep.description }}
                    </p><hr>
                  </div>
                  <!-- creator col -->
                  <div class="col-12 justify-content-center">
                    <router-link :to="{name: 'ProfilePage', params:{id: state.activeKeep.creator.id}}" data-dismiss="modal">
                      <p class="mt-2">
                        <img :src="state.activeKeep.creator.picture" class="rounded-circle creator-img" alt=""> {{ state.activeKeep.creator.name }}
                      </p>
                    </router-link>
                  </div>
                </div>

                <!-- row 3 -->
                <div class="row justify-content-between align-items-center">
                  <div class="col-10">
                    <!-- dropdown col -->
                    <div class="dropdown">
                      <button class="btn btn-outline-primary dropdown-toggle"
                              type="button"
                              id="dropdownMenuButton"
                              data-toggle="dropdown"
                              aria-haspopup="true"
                              aria-expanded="false"
                      >
                        Add To Vault
                      </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                      </div>
                    </div>
                  </div>
                  <!-- delete column -->
                  <div class="col-2 justify-content-center align-items-center d-flex">
                    <i class="fa fa-trash text-danger action" @click="deleteKeep" v-if="state.activeKeep.creatorId == state.account.id" aria-hidden="true"></i>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'KeepModalComponent',
  // TODO ? - props for active keep on modal?
  setup() {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account)
    })
    return {
      state
      // TODO deleteKeep()
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.keep-img{
  max-width: 100%;
}
.creator-img{
 width: 1.5rem;
 height: 1.5rem;
}
.action{
  cursor: pointer;
}
</style>
