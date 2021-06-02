<template>
  <!-- card start -->
  <router-link :to="{name: 'VaultPage', params:{id: vault.creator.id}}">
    <div class="card text-white shadow" title="View Vault">
      <img src="//placehold.it/200X200" class="card-img w-100" alt="...">
      <a href="" data-toggle="modal" data-target="#vault-modal"></a>
      <div class="card-img-overlay d-flex align-items-end">
        <h5 class="card-title mb-0 text-white">
          {{ vault.name }}Vault Name
        </h5>
      </div>
    </div>
  </router-link>
  <!-- End card -->
</template>

<script>
export default {
  name: 'Component',
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
