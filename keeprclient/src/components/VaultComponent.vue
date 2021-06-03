<template>
  <!-- card start -->
  <!-- <router-link :to="{name: 'VaultPage', params:{id: vault.creator.id}}"> -->
  <div class="col-3">
    <div class="card text-white shadow" title="View Vault">
      <img :src="vault.img" class="card-img w-100" alt="...">
      <a href="" data-toggle="modal" data-target="#vault-modal"></a>
      <div class="card-img-overlay d-flex align-items-end">
        <p class="card-title mb-0 text-white">
          {{ vault.name }}
        </p>
      </div>
    </div>
  </div>
  <!-- </router-link> -->
  <!-- End card -->
</template>

<script>
export default {
  name: 'VaultComponent',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
