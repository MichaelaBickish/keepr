<template>
  <div class="profile-page container-fluid">
    <div class="row my-3" v-if="state.activeProfile">
      <div class="col-md-3">
        <img :src="state.activeProfile.picture" alt="" class="mx-3">
      </div>
      <div class="col-md-7">
        <h1>{{ state.activeProfile.name }}</h1>
        <p>Vaults: {{ state.vaults.length }}</p>
        <p>Keeps: {{ state.keeps.length }}</p>
      </div>
    </div>
    <div class="row my-3">
      <div class="col">
        <h2>
          Vaults <button title="Open Create Vault Form"
                         type="button"
                         class="btn btn-outline-success"
                         data-toggle="modal"
                         data-target="#new-vault-form"
                         v-if="state.account.id == route.params.id"
          >
            <i class="fas fa-plus" aria-hidden="true"></i>
          </button>
        </h2>
      </div>
    </div>
    <div class="row row-reverse my-3" v-if="state.vaults">
      <VaultComponent v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
    </div>
    <div class="row my-3">
      <div class="col">
        <h2>
          Keeps <button title="Open Create Keep Form"
                        type="button"
                        class="btn btn-outline-success"
                        data-toggle="modal"
                        data-target="#new-keep-form"
                        v-if="state.account.id == route.params.id"
          >
            <i class="fas fa-plus" aria-hidden="true"></i>
          </button>
        </h2>
      </div>
    </div>
    <div class="row my-3 mx-1" v-if="state.keeps">
      <div class="card-columns">
        <!-- Inject Keeps here {{ state.profileKeeps }} -->
        <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { useRoute } from 'vue-router'
import Notification from '../utils/Notification'
import { AppState } from '../AppState'
import { computed, reactive, onMounted } from 'vue'
import { profilesService } from '../services/ProfilesService'

export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.profileKeeps),
      vaults: computed(() => AppState.profileVaults)
    })
    onMounted(async() => {
      try {
        await profilesService.getActiveProfile(route.params.id)
        await profilesService.getProfileKeeps(route.params.id)
        await profilesService.getProfileVaults(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state,
      route
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
