<template>
  <div class="container-fluid" v-if="state.activeVault">
    <div class="row my-3 mx-2">
      <div class="col-12">
        <div class="row">
          <div class="col-12 justify-content-end d-flex" v-if="state.activeVault">
            <i class="fa fa-trash text-danger action" @click="deleteVault(state.activeVault)" v-if="state.activeVault.creatorId == state.account.id" aria-hidden="true" title="Delete Vault"></i>
          </div>
        </div>
        <h1>
          {{ state.activeVault.name }}
        </h1>
        <h2 class="font-weight-lighter">
          {{ state.activeVault.description }}
        </h2>
        <p class="font-weight-bold text-secondary">
          Keeps: {{ state.vaultKeeps.length }}
        </p>
      </div>
    </div>
    <div class="row my-3 mx-1" v-if="state.vaultKeeps">
      <div class="card-columns">
        <!-- Inject Keeps here {{ state.profileKeeps }} -->
        <VKeepComponent v-for="keep in state.vaultKeeps" :key="keep.id" :keep="keep" />
      </div>
    </div>
    <div class="row my-3 mx-1" v-if="state.vaultKeeps.length == 0">
      <h3 class="font-weight-lighter font-italic">
        There are no keeps in this vault yet!
      </h3>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'

import Notification from '../utils/Notification'
import { AppState } from '../AppState'
export default {
  name: 'VaultDetailsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
        await vaultsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      route,
      state,
      async deleteVault(activeVault) {
        try {
          if (await Notification.confirmAction('Delete This Vault?', "This action will delete your vault and all it's keeps", 'warning', 'Yes, Delete Vault!')) {
            await vaultsService.deleteVault(activeVault)
            Notification.toast('Your Vault Has Been Deleted!', 'success')
          }
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
.action{
  cursor: pointer;
}
</style>
