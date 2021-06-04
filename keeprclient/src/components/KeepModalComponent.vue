<template class="Keep-Modal-Component" v-if="state.account">
  <div class="modal" id="keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="container-fluid" v-if="state.activeKeep">
            <div class="row justify-content-end">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close" title="Close Keep">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="row" v-if="state.activeKeep">
              <div class="col-12 col-md-6">
                <img :src="state.activeKeep.img" class="keep-img">
              </div>
              <div class="col-12 col-md-6">
                <!-- row 1 -->
                <div class="row justify-content-center mb-2">
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
                </div>

                <!-- row 3 -->
                <div class="row justify-content-between align-items-end" v-if="state.user.isAuthenticated">
                  <!-- creator col -->
                  <div class="col-12 justify-content-center mt-3">
                    <router-link :to="{name: 'ProfilePage', params:{id: state.activeKeep.creator.id}}" data-dismiss="modal">
                      <p class="mt-2" title="View Profile">
                        <img :src="state.activeKeep.creator.picture" class="rounded-circle creator-img" alt=""> {{ state.activeKeep.creator.name }}
                      </p>
                    </router-link>
                  </div>
                  <div class="col-10" v-if="state.currentUserVaults">
                    <!-- dropdown col -->
                    <div class="dropdown" title="Add This Keep To Vault">
                      <button class="btn btn-outline-primary dropdown-toggle px-4"
                              type="button"
                              id="dropdownMenuButton"
                              data-toggle="dropdown"
                              aria-haspopup="true"
                              aria-expanded="false"
                      >
                        Add To Vault
                      </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <option class="dropdown-item vaults px-2 action"
                                v-for="currentUserVault in state.currentUserVaults"
                                :key="currentUserVault.id"
                                :vault="currentUserVault"
                                :keep="state.activeKeep"
                                @click="createVaultKeep(currentUserVault.id)"
                        >
                          <p>
                            {{ currentUserVault.name }}
                          </p>
                        </option>
                      </div>
                    </div>
                  </div>
                  <!-- delete column -->
                  <div class="col-2 justify-content-center align-items-center d-flex">
                    <i class="fa fa-trash text-danger action" @click="deleteKeep(state.activeKeep)" v-if="state.activeKeep.creatorId == state.account.id" aria-hidden="true" title="Delete Keep"></i>
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
import Notification from '../utils/Notification'
import { keepsService } from '../services/KeepsService'
import { vaultKeepsService } from '../services/VaultKeepsService'
import $ from 'jquery'
export default {
  name: 'KeepModalComponent',
  // TODO ? - props for active keep on modal?
  setup() {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      vaults: computed(() => AppState.profileVaults),
      currentUserVaults: computed(() => AppState.currentUserVaults)
    })
    return {
      state,
      async deleteKeep(activeKeep) {
        try {
          if (await Notification.confirmAction('Delete This Keep?', 'Your keep will be permanently deleted.', 'warning', 'Yes, Delete Keep!')) {
            await keepsService.deleteKeep(activeKeep)
            Notification.toast('Your Keep Has Been Deleted!', 'success')
            $('#keep-modal').modal('hide')
          }
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      async createVaultKeep(vaultId) {
        try {
          // debugger
          const newVaultKeep = {
            keepId: state.activeKeep.id,
            vaultId: vaultId
          }
          await vaultKeepsService.createVaultKeep(newVaultKeep)
          Notification.toast('This keep has been saved to your vault!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
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
