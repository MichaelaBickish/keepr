<template>
  <div class="container-fluid" v-if="state.activeVault">
    <div class="row my-3 mx-2">
      <div class="col-12">
        <h1>
          {{ state.activeVault.name }}
        </h1>
        <p class="font-weight-bold text-secondary">
          Keeps:
        </p>
      </div>
    </div>
    {{ state.activeVault }}
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
      activeVault: computed(() => AppState.activeVault)
    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      route,
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
