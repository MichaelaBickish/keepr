<template>
  <!-- card start -->
  <div class="col-3">
    <router-link :to="{name: 'VaultDetailsPage', params:{id: vault.id}}">
      <div class="card text-white shadow active" title="View Vault">
        <img :src="vault.img" class="card-img w-100" alt="...">
        <a href="" data-toggle="modal" data-target="#vault-modal"></a>
        <div class="card-img-overlay d-flex align-items-end">
          <p class="card-title mb-0 text-white">
            {{ vault.name }}
          </p>
        </div>
      </div>
    </router-link>
  </div>
  <!-- End card -->
</template>

<script>
// import { AppState } from '../AppState'
export default {
  name: 'VaultComponent',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.active{
  cursor: pointer;
}
</style>
