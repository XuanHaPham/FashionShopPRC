<template>
  <div>
    <VmHero></VmHero>
    <div class="columns">
      <div class="column is-one-fifth" style="margin-left:20px;">
          <aside class="menu ">
            
  <ul class="menu-list">
    <li><a @click="searchByCatelogy(-1)">All products</a></li>
  </ul>
  <p class="menu-label">
    CLOTHINGS
  </p>
  <ul class="menu-list">
    <li><a @click="searchByCatelogy(3)">Clothing set</a></li>
    <li><a @click="searchByCatelogy(4)">Dresses</a></li>
    <li><a @click="searchByCatelogy(5)">Skirts</a></li>
    <li><a @click="searchByCatelogy(6)">Shorts</a></li>
    <li><a @click="searchByCatelogy(7)">Jumpsuit</a></li>
    <li><a @click="searchByCatelogy(8)">Jackets</a></li>
  </ul>
  <p class="menu-label">
    Swimwear
  </p>
  <ul class="menu-list">
    <li><a @click="searchByCatelogy(9)">Bundles</a></li>
    <li><a @click="searchByCatelogy(10)">One pieces</a></li>
    <li><a @click="searchByCatelogy(11)">Rashguands</a></li>
    <li><a @click="searchByCatelogy(12)">Bikinis</a></li>
    <li><a @click="searchByCatelogy(13)">Cover-ups</a></li>
  </ul>
  <!-- <p class="menu-label">
    BAGS AND WALLETS
  </p>
  <ul class="menu-list">
    <li><a>Coin Pure</a></li>
    <li><a>Fashion Bags</a></li>
    <li><a>Multipurpose Bags</a></li>
    <li><a>Wallets</a></li>
  </ul>
  <p class="menu-label">
    SHOES
  </p>
  <ul class="menu-list">
    <li><a>Heels</a></li>
    <li><a>Sandals</a></li>
    <li><a>Sneaker</a></li>
  </ul> -->
</aside>
      </div>
        <div class="column auto">
    <VmProductsList></VmProductsList>
    </div>
    </div>
  </div>
</template>

<script>
import VmProductsList from '@/components/products_list/ProductsListContainer';
import VmHero from '@/components/hero/Hero';

export default {
  name: 'index',
  components: {
    VmProductsList,
    VmHero
  },
  methods: {
		searchByCatelogy (value) {
			if (value > 0) {
				this.$store.commit('setHasUserCategory', true);
				this.$store.commit('setProductTitleCategory', value);
			} else {
				this.$store.commit('setHasUserCategory', false);
				this.$store.commit('setProductTitleCategory', -1);
			}
		}
	}
};
</script>
