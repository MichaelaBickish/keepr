<template>
  <div class="component">
    Vaults Page
  </div>
</template>

<script>
import { useRoute } from 'vue-router'
export default {
  name: 'Component',
  setup() {
    const route = useRoute()
    return {
      route
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
