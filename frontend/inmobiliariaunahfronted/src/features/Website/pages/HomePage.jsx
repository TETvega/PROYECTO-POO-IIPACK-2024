import { ServicesSection } from "../components";
import { FeaturedProducts } from "../components";
import { HeroSection } from "../components";
import { ProductsSection } from "../components/ProductsSection";

export const HomePage = () => {
  return (
    <div>
      <HeroSection />
      <ServicesSection />
      <ProductsSection />
      <FeaturedProducts />
    </div>
  );
};