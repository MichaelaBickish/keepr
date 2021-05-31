<template>
  <!-- card start -->
  <div class="card text-white shadow">
    <img :src="keep.img" class="card-img" alt="...">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <h5 class="card-title mb-0">
        {{ keep.name }}
      </h5>
      <img :src="keep.creator.img" alt="">
    </div>
  </div>
  <!-- End card -->
</template>

<script>
export default {
  name: 'KeepComponent',
  props: {
    keep: {
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
