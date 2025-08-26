import { Module } from "@nestjs/common";
import { CcService } from "./cc.service";
import { CcController } from "./cc.controller";
import { CcResolver } from "./cc.resolver";

@Module({
  controllers: [CcController],
  providers: [CcService, CcResolver],
  exports: [CcService],
})
export class CcModule {}
