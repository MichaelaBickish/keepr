import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keeps: [],
  activeKeep: null,
  activeProfile: null,
  profileKeeps: [],
  vaults: [],
  activeVault: null,
  profileVaults: [],
  currentUserVaults: [],
  vaultKeeps: []
})
