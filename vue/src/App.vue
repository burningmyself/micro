<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script lang="ts">
/// <reference path="./regex.ts" />

import { Component, Vue } from 'vue-property-decorator'

@Component({
  name: 'App'
})
export default class extends Vue {}
</script>
