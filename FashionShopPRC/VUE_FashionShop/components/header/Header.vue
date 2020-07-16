<template>
  <div>
    <nav class="navbar" role="navigation" aria-label="main navigation">
      <div class="navbar-brand">
        <nuxt-link :to="{ name: 'index' }" class="navbar-item">
          <h1 class="title is-3 is-flex-mobile"></h1>
        </nuxt-link>

        <a role="button" class="navbar-burger burger" @click="isMenuOpen = !isMenuOpen" aria-label="menu" aria-expanded="false">
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>

      <div class="navbar-menu is-active">
        <div class="navbar-start">
          <div class="navbar-item field">
            <VmSearch></VmSearch>
          </div>
        </div>
        
        <div class="navbar-end">
          <div class="navbar-item social">
            <a href="https://www.facebook.com/eazyfashi0n/" class="icon is-large" :title="facebookTooltip">
              <i class="fa fa-facebook"></i>
            </a>
            <a href="https://twitter.com/ezayfashion" class="icon is-large" :title="twitterTooltip">
              <i class="fa fa-twitter is-large"></i>
            </a>
            <a href="https://www.instagram.com/eazyfashionph/" class="icon is-large" :title="instagramTooltip">
              <i class="fa fa-instagram"></i>
            </a>
            <a href="https://www.linkedin.com/company/easy-fashion-ltd-/about/" class="icon is-large" :title="linkedinTooltip">
              <i class="fa fa-linkedin"></i>
            </a>
            <span width="40px"/>
            <nuxt-link class="navbar-item" :to="{ name: 'Contact-contact' }"  align="center" >
				    <div class="icon">
                <i class="fa fa-commenting"></i>
              </div>
              <h1> Contact Us</h1>
				</nuxt-link>
            <a href="#contact" margin="20px">
              
        </a>
          </div>
          <div class="navbar-item shopping-cart" @click="showCheckoutModal">
            <span class="icon">
              <i class="fa fa-shopping-cart"></i>
            </span>
            <span :class="[numProductsAdded > 0 ? 'tag is-info' : '']">{{ numProductsAdded }}</span>
          </div>
        </div>
      </div>

      <!-- For mobile and tablet -->
      <div v-show="isMenuOpen" class="navbar-end">
        <VmMenu></VmMenu>
      </div>

      <!-- For desktop -->
      <div class="navbar-end is-hidden-mobile">
        <VmMenu></VmMenu>
      </div>
    </nav>
  </div>
</template>

<script>
  import VmMenu from '../menu/Menu';
  import VmSearch from '../search/Search';

  export default {
    name: 'VmHeader',

    data () {
      return {
        linkedinTooltip: 'Follow us on Linkedin',
        facebookTooltip: 'Follow us on Facebook',
        twitterTooltip: 'Follow us on Twitter',
        instagramTooltip: 'Follow us on Instagram',
        isCheckoutActive: false,
        isMenuOpen: false
      }
    },

    components: {
      VmSearch,
      VmMenu
    },

    computed: {
      numProductsAdded () {
        return this.$store.getters.productsAdded.length;
      }
    },

    methods: {
      showCheckoutModal () {
        this.$store.commit('showCheckoutModal', true);
      }
    }
  };
</script>

<style lang="scss" scoped>
  .title {
    background: url('../../static/logo.png') no-repeat;
    background-position: 50% 50%;
    background-size: 165px;
    width: 175px;
    height: 75px;
  }
  .shopping-cart {
    cursor: pointer;
  }
  a {
    color: grey;
  }

  span { 
	float: left;
	width: 60px;
}
</style>
